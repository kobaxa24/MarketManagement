using Market.Extensions.Attributes;

namespace Market.DTO
{
    public class Attribute
    {
        [IgnoreForInsert]
        public int AttributeID { get; set; }
        public string AttributeName { get; set; } = null!;
        public int AttributeType { get; set; }

        [IgnoreForInsert, IgnoreForUpdate]
        public bool IsActive { get; set; } = true;
        
        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [IgnoreForInsert, IgnoreForUpdate]
        public DateTime? UpdatedDate { get; set; }
    }
}
