using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Customer
    {
        [IgnoreForInsert]
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int CustomerLoyaltyPoints { get; set; }

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
