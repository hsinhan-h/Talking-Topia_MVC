using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ECpayService
    {
        /// <summary>
        /// 驗證綠界API回傳的結果
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <returns></returns>
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
                return EOrderStatus.Failed;
            }
        }
    }
}
