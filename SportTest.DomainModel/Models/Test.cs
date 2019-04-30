using SportTest.DomainModel.Enums;
using System;
using System.Collections.Generic;

namespace SportTest.DomainModel.Models
{
    public class Test: BaseModel
    {
        public TestType TestType { get; set; }

        public DateTime TestDate { get; set; }

        public virtual List<TestDetail> TestDetails { get; set; }
    }
}
