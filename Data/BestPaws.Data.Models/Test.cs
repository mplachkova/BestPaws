﻿namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Test : BaseDeletableModel<int>
    {
        public TestResult TestResult { get; set; }

        public int TestResultId { get; set; }

        public TestType TestType { get; set; }

        public int TestTypeId { get; set; }

        public Pet Pet { get; set; }

        public int PetId { get; set; }

        public DateTime FromDate { get; set; }

        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public string Comments { get; set; }
    }
}
