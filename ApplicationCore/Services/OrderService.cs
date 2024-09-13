using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<ShoppingCart> shoppingCartRepository, IShoppingCartService shoppingCartService)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<GetAllOrderResult> GetAllOrder(int memberId)
        {
            var orders = await _orderRepository.ListAsync(item => item.MemberId == memberId);
            var getOrderItem = new List<GetOrderItem>();
            foreach (var order in orders)
            {
                getOrderItem.Add
                (new GetOrderItem
                    {
                        OrderId = order.OrderId,
                        MemberId = order.MemberId,
                        PaymentType = order.PaymentType,
                        TotalPrice = order.TotalPrice,
                        TransactionDate = order.TransactionDate,
                        CouponPrice = order.CouponPrice,
                        TaxIdNumber = order.TaxIdNumber,
                        InvoiceType = order.InvoiceType,
                        VATNumber = order.VATNumber,
                        SentVatemail = order.SentVatemail,
                        OrderStatusId = order.OrderStatusId,
                    }
                );
            }
            var result = new GetAllOrderResult
            {
                GetOrderItems = getOrderItem,
            };
            return result;
        }

        // 創建訂單並處理交易(需刷新交易狀態/OrderStatusId，另外invice尚未考慮)
        public async Task<bool> CreateOrderAsync(int memberId,int courseId, string paymentType)
        {
            using var transaction = _orderRepository.BeginTransaction();
            {
                try
            {
                // 如果購物車為空，則無需處理
                if (!_shoppingCartService.HasCartItem(memberId, courseId))
                {
                    throw new InvalidOperationException("購物車為空，無法生成訂單。");
                }
                //todo: 新增Orders資料列，OrderStatus為待付款
                var order = await _shoppingCartRepository.ListAsync(x => x.MemberId == memberId);
                var totalPrice = order.Sum(x => x.Quantity * x.UnitPrice);
                //todo: 成功或失敗都應先寫入資料庫，由訂單狀態去判定成功與否就好
                var orders = new Order
                {
                    MemberId = memberId,
                    PaymentType = paymentType,
                    TotalPrice = totalPrice,
                    TransactionDate = DateTime.Now,
                    InvoiceType = 1,
                    OrderStatusId = (short)EOrderStatus.Outstanding,
                    Cdate = DateTime.Now,
                };
            }
            catch (Exception ex)
            {
            
            
            
            }



            
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

        public EOrderStatus ValidatePaymentResult(int rtnCode)
        {
            //todo: int rtnCode = 2(ATM) || 10100073(CVS / BARCODE)為成功，其餘皆為失敗
            //是否先判斷rtnCodeType為ATM或CVS/BARCODE
            //todo: 訂單加密、解密由EC API端實作，但ServerSide要考慮傳送與接收相同檢查碼的問題
            if (rtnCode == 2 || rtnCode == 10100073)
            {
                return EOrderStatus.Success;
            }
            else
            {
                return EOrderStatus.Failure;
            }
        }

        /// <summary>
        /// 驗證綠界API回傳的結果
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <returns></returns>
        public TimeSpan ConvertSmallintToTime(short timeValue)
        {
            int hours = timeValue / 100;
            int minutes = timeValue % 100;

            return new TimeSpan(hours, minutes, 0);
        }
    }
}
