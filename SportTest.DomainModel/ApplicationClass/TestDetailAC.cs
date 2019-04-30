using SportTest.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportTest.DomainModel.ApplicationClass
{
    public class TestDetailAC
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfParticipants { get; set; }

        public string TestType { get; set; }
    }
}
