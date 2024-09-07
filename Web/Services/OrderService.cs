using Microsoft.Extensions.Hosting;
using Web.ViewModels;

namespace Web.Services
{
    public class OrderService
    {
        private readonly IRepository _repository;
        //private readonly IHostedService _hostedService;
        private readonly TalkingTopiaContext _dbContext;

        public OrderService(IRepository repository, IHostedService hostedService, TalkingTopiaContext dbContext)
        {
            _repository = repository;
            //_hostedService = hostedService;
            _dbContext = dbContext;
        }
        //todo: 訂單加密 -> IHostedService
        //todo: 判斷交易是否成功 -> 接收ECPay回應成功/失敗訊息 -> 支付系統延遲的循環機制
        //      失敗 rollback -> db的Transaction機制 -> 提示Member重試或連繫客服
        //todo: 成功 寫入資料庫 -> Orders && OrderDetails -> SaveChangeAsync()
        //todo: 將該筆交易渲染至訂單完成頁面 -> 撈Orders && OrderDetails 最新一筆交易 && MemberId

        /// <summary>
        /// 驗證會員
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public bool HasMemberData(int memberId)
        {
            return _repository.GetAll<Member>().Any(x => x.MemberId == memberId);
        }
        /// <summary>
        /// 綠界回應代號
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <returns></returns>
        //public Task<bool> IsSuccess(int rtnCode)
        //{
            //todo: int rtnCode = 2 (ATM) || 10100073 (CVS/BARCODE)為成功，其餘皆為失敗


         //   return true;
        //}



        /*public async Task<OperationResult> Create(Order)
        {
            var result = new OperationResult();
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //todo: 驗證會員
                    if (!HasMemberData(memberId))
                    { throw new Exception("會員不存在，請重新操作"); }
                    





                }
                catch (Exception ex)
                {
                    result.IsSuccessful = false;
                    result.Exception = ex;
                    transaction.Rollback();
                }












            }
            
        }*/

        public enum OrderStatusId
        {
            Success = 1,
            Failure = 2,
            PendingPayment = 3,
        }
    }
}
