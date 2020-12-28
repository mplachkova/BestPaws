namespace BestPaws.Web.ViewModels.Treatments
{
    using System.Collections.Generic;

    public class TreatmentListViewModel
    {
        public int PetId { get; set; }

        public string PetName { get; set; }

        public IEnumerable<TreatmentViewModel> Treatments { get; set; }
    }
}
