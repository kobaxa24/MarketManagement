using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class StockTransaction
    {
        [IgnoreForInsert]
        public int StocktrancationID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int EmployeeID { get; set; }
        public int Quantity { get; set; }
        [IgnoreForInsert]
        public DateTime TrancationDate { get; set; } = DateTime.Now;
    }
}
