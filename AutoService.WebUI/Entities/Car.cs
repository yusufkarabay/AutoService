namespace AutoService.WebUI.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string CaseType { get; set; }
        public int ModelYear { get; set; }
        public bool IsAvailable { get; set; }
        public string Notes { get; set; }
        public string Plate { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

    }

    
}
