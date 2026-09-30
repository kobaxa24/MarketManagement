using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Supplier
    {
        [IgnoreForInsert]
        public int SupplierID { get; set; }
        public int CountryID { get; set; }
        public string SupplierName { get; set; } = null!;

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
