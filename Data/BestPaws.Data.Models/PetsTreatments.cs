namespace BestPaws.Data.Models
{
    using BestPaws.Data.Common.Models;

    public class PetsTreatments : BaseDeletableModel<int>
    {
        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }
    }
}
