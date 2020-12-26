namespace BestPaws.Web.ViewModels.PetCenter
{
    using System.Collections.Generic;

    public class PetCenterListViewModel
    {
        public IEnumerable<PetCenterViewMode> Pets { get; set; }
    }
}
