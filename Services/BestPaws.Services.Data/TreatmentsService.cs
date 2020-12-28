namespace BestPaws.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BestPaws.Data.Common.Repositories;
    using BestPaws.Data.Models;
    using BestPaws.Services.Mapping;

    public class TreatmentsService : ITreatmentsService
    {
        private readonly IDeletableEntityRepository<PetsTreatments> petTreatmentRepoistory;

        public TreatmentsService(IDeletableEntityRepository<PetsTreatments> petTreatmentRepo)
        {
            this.petTreatmentRepoistory = petTreatmentRepo;
        }

        public IEnumerable<T> GetAll<T>(int id)
        {
            var treatmentList = this.petTreatmentRepoistory
                .AllAsNoTracking()
                .Where(x => x.PetId == id)
                .Select(x => x.Treatment)
                .To<T>()
                .ToList();
            return treatmentList;
        }
    }
}
