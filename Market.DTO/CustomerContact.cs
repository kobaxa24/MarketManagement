using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class CustomerContact
    {
        [IgnoreForInsert]
        public int CustomerContactID { get; set; }
        public string CustomerEmail { get; set; } = null!;
        public int CustomerID { get; set; }
        public int ContactType { get; set; }
        public string ContactValue { get; set; } = null!;

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsNotActive { get; set; }

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
