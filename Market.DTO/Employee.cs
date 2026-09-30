using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Employee
    {
        [IgnoreForInsert]
        public int EmployeeID { get; set; }
        public int EmployeeRoleID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }

}
