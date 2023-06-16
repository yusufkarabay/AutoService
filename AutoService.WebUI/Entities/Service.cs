namespace AutoService.WebUI.Entities
{
    public class Service : BaseEntity
    {
        public DateTime? ServiceComeDate { get; set; }
        public DateTime? ServiceLeaveDate { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ServicePrice { get; set; }
        public string ServiceNotes { get; set; }
        public bool IsUnderWarranty { get; set; }
      
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
