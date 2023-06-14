namespace AutoService.WebUI.Entities
{
    public class Sale:BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime? SaleDate { get; set; }=DateTime.UtcNow;
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
