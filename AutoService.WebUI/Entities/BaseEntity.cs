using System.ComponentModel.DataAnnotations;

namespace AutoService.WebUI.Entities
{
    public interface IBaseEntity
    {
         Guid Id { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
