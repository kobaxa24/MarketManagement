namespace Market.DTO
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
    }
}
