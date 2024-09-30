namespace Infrastructure.Interfaces.ECpay
{
    /// <summary>
    /// 訂單的商品資料。
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// 商品名稱。
        /// </summary>
        string CourseName { get; set; }
        /// <summary>
        /// 商品單價
        /// </summary>
        int UnitPrice { get; set; }
        /// <summary>
        /// 商品小計。
        /// </summary>
        int SubPrice { get; set; }
        /// <summary>
        /// 購買數量。
        /// </summary>
        /// <value></value>
        int Quantity { get; set; }
        /// <summary>
        /// 課程類別：25或50
        /// </summary>
        short CourseType { get; set; }

    }
}