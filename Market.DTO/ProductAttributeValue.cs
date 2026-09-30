namespace Market.DTO
{
    public class ProductAttributeValue
    {
        public int ProductID { get; set; }
        public int AttributeID { get; set; }
        public string? TextValue { get; set; }
        public decimal? NumberValue { get; set; }
        public DateTime? DateValue { get; set; }
        public bool? BooleanValue { get; set; }
    }
}
