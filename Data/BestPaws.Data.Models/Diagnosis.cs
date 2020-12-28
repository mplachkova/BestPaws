namespace BestPaws.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BestPaws.Data.Common.Models;

    public class Diagnosis : BaseDeletableModel<int>
    {
        public Diagnosis()
        {
            this.DiagnosesPets = new HashSet<PetsDiagnoses>();
        }

        public string Name { get; set; }

        public string Comments { get; set; }

        public Doctor Doctor { get; set; }

        public string DoctorId { get; set; }

        public DateTime FromDate { get; set; }

        public ICollection<PetsDiagnoses> DiagnosesPets { get; set; }
    }
}
