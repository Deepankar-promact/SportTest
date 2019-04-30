using SportTest.DomainModel.Enums;

namespace SportTest.DomainModel.Models
{
    public class Role: BaseModel
    {
        public RoleType UserRole { get; set; }
    }
}
