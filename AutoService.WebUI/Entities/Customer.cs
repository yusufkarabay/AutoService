namespace AutoService.WebUI.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
