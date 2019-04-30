using System.ComponentModel.DataAnnotations.Schema;

namespace SportTest.DomainModel.Models
{
    public class User: BaseModel
    {
        public string Name { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role UserRole { get; set; }
    }
}
