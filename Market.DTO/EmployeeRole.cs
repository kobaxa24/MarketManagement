using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class EmployeeRole
    {
        [IgnoreForInsert]
        public int EmployeeRoleID { get; set; }
        public string RoleName { get; set; } = null!;

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
