using System.ComponentModel.DataAnnotations.Schema;

namespace SportTest.DomainModel.Models
{
    public class TestDetail: BaseModel
    {
        public int TestId { get; set; }

        public int AtheleteId { get; set; }

        public double Distance { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

        [ForeignKey("AtheleteId")]
        public virtual User User { get; set; }
    }
}
