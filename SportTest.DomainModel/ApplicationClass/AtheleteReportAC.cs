using System;
using System.Collections.Generic;
using System.Text;

namespace SportTest.DomainModel.ApplicationClass
{
    public class AtheleteReportAC
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public string AtheleteName { get; set; }

        public int AtheleteId { get; set; }

        public double Distance { get; set; }

        public string FitnessRating { get; set; }
    }
}
