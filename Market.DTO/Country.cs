using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Country
    {
        [IgnoreForInsert]
        public int CountryID { get; set; }
        public string CountryName { get; set; } = null!;

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
