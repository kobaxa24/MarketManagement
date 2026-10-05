using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class EmployeeContact
    {
        [IgnoreForInsert]
        public int EmployeeContactID { get; set; }
        public int EmployeeID { get; set; }
        public int ContactType { get; set; }
        public string ContactValue { get; set; } = null!;

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
