namespace AutoService.WebUI.Entities
{
    public class Sale:BaseEntity
    {
        public int Price { get; set; }
        public DateTime? SaleDate { get; set; }
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
