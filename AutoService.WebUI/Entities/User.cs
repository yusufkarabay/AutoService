namespace AutoService.WebUI.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }=DateTime.UtcNow;
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }

   
}
