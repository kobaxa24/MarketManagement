using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class SalesItem
    {
        [IgnoreForInsert] 
        
        public int SalesItemID { get; set; }
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }

}
