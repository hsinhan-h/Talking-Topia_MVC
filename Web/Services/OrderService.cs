using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using Web.ViewModels;

namespace Web.Services
{
    public class OrderService
    {
        private readonly IRepository _repository;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly TalkingTopiaContext _dbContext;
        //todo: 支付延遲的循環機制(若連線問題要在一定時間內重覆傳送授權需求，少說得三次)
        //     ↓DI註冊導致Program無法正常運行，出現無法連結至網路Q Q
        //private readonly IHostedService _hostedService;
        public OrderService(IRepository repository, ShoppingCartService shoppingCartService, TalkingTopiaContext dbContext)
        {
            _repository = repository;
            _shoppingCartService = shoppingCartService;
            _dbContext = dbContext;
        }

        //todo: 將該筆交易渲染至訂單完成頁面 -> 撈Orders && OrderDetails 最新一筆交易 && MemberId
        public async Task<ShoppingCartInfoListViewModel> GetData(int memberId)
        {
            var result = await (from item in (from lo in _repository.GetAll<Order>()
                                              where lo.MemberId == memberId
                                              orderby lo.Cdate descending
                                              select lo).Take(1)
                                join od in _repository.GetAll<OrderDetail>() on item.OrderId equals od.OrderId
                                join course in _repository.GetAll<Course>() on od.CourseId equals course.CourseId
                                join tutor in _repository.GetAll<Member>() on course.TutorId equals tutor.MemberId
                                join booking in _repository.GetAll<Booking>() on memberId equals booking.StudentId
                                where booking.CourseId == course.CourseId
                                orderby booking.Cdate descending
                                select new ShoppingCartInfoViewModel
                                {
                                    CourseId = od.CourseId,
                                    TrackingNumber = "",
                                    FullName = tutor.FirstName + " " + tutor.LastName,
                                    CourseTitle = od.CourseTitle,
                                    CourseQuantity = od.Quantity,
                                    SubtotalNTD = od.TotalPrice,
                                    TaxIdNumber = item.TaxIdNumber,
                                    OrderDatetime = item.TransactionDate.ToString("yyyy-MM-dd hh-mm"),
                                    BookingDate = booking.BookingDate,
                                    //BookingTime = ConvertSmallintToTime((short)booking.BookingTime),
                                }).ToListAsync();

            return new ShoppingCartInfoListViewModel
            {
                ShoppingCartInfoList = result
            };
        }

        /// <summary>
        /// 驗證綠界API回傳的結果
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <returns></returns>
        public OrderStatusId ValidatePaymentResult(int rtnCode)
        {
            //todo: int rtnCode = 2(ATM) || 10100073(CVS / BARCODE)為成功，其餘皆為失敗
            //是否先判斷rtnCodeType為ATM或CVS/BARCODE
            //todo: 訂單加密、解密由EC API端實作，但ServerSide要考慮傳送與接收相同檢查碼的問題
            if (rtnCode == 2 || rtnCode == 10100073)
            {
                return OrderStatusId.Success;
            }
            else
            {
                return OrderStatusId.Failure;
            }
        }

        // 創建訂單並處理交易(需刷新交易狀態/OrderStatusId，另外invice尚未考慮)
        public async Task<bool> CreateOrder(int memberId, string paymentType, short orderStatusId)
        {
            // 如果購物車為空，則無需處理
            if (!_shoppingCartService.HasCartData(memberId))
            {
                throw new InvalidOperationException("購物車為空，無法生成訂單。");
            }

            // todo: 新增Orders資料列，OrderStatus為待付款
            var cartItems = await _dbContext.ShoppingCarts.Where(x => x.MemberId == memberId).ToListAsync();
            var totalPrice = cartItems.Sum(x => x.Quantity * x.UnitPrice);
            //todo: 成功或失敗都應寫入資料庫？由訂單狀態去判定成功與否就好？
            var order = new Order
            {
                MemberId = memberId,
                PaymentType = paymentType,
                TotalPrice = totalPrice,
                TransactionDate = DateTime.Now,
                InvoiceType = 1,
                OrderStatusId = orderStatusId,
                Cdate = DateTime.Now,
            };

            using var transaction = _dbContext.Database.BeginTransaction();
            {
                try
                {
                    // 保存訂單資料到資料庫
                    _repository.Create(order);

                    //todo: 確認rtnCode狀態

                    // 保存訂單明細資料
                    foreach (var item in cartItems)
                    {
                        var orderId = await _dbContext.Orders.Where(x => x.MemberId == memberId).OrderByDescending(x => x.Cdate).ToListAsync();
                        var orderDetail = from orderItem in orderId
                                          join cart in _repository.GetAll<ShoppingCart>() on orderItem.MemberId equals cart.MemberId
                                          join course in _repository.GetAll<Course>() on cart.CourseId equals course.CourseId
                                          join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                                          join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                                          select new OrderDetail
                                          {
                                              OrderId = orderItem.OrderId,
                                              CourseId = course.CourseId,
                                              UnitPrice = cart.UnitPrice,
                                              Quantity = cart.Quantity,
                                              DiscountPrice = 0,
                                              TotalPrice = cart.TotalPrice,
                                              CourseType = cart.CourseType,
                                              CourseTitle = course.Title,
                                              CourseSubject = subject.SubjectName,
                                              CourseCategory = category.CategorytName,
                                          };

                        _repository.Create(orderDetail);
                        //todo: 成功 寫入資料庫 -> Orders && OrderDetails -> SaveChangeAsync()不給我Async!!
                        _repository.SaveChanges();
                    }
                    // 清空購物車
                    //_shoppingCartService.ClearCart(MemberId);

                    // todo: Commit!!
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // todo: 失敗 rollback -> 提示Member重試或連繫客服
                    transaction.Rollback();
                    // 記錄錯誤訊息(待討論參考Bill叔OperationResult作法，產生ErrorLog.txt)
                    Console.WriteLine("訂單創建失敗：" + ex.Message);
                    return false;
                }

                return true;
            }
        }
        public TimeSpan ConvertSmallintToTime(short timeValue)
        {
            int hours = timeValue / 100;
            int minutes = timeValue % 100;

            return new TimeSpan(hours, minutes, 0);
        }
    }

    public enum OrderStatusId
    {
        Success = 1,
        Failure = 2,
        PendingPayment = 3,
    }
}

