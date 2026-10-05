using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class UserAccount
    {
        [IgnoreForInsert]
        public int EmployeeID { get; set; }
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public bool IsEnabled { get; set; }

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
