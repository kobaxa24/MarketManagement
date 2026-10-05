using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Sale
    {
        [IgnoreForInsert]
        public int SaleID { get; set; }
        public int? CustomerID { get; set; }
        public int EmployeeID { get; set; }
        [IgnoreForInsert]
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}
