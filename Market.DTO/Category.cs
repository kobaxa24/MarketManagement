using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Category
    {
        [IgnoreForInsert]
        public int CategoryID { get; set; }
        public int? ParentID { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;
        
        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}