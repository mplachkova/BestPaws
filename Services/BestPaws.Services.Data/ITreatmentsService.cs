namespace BestPaws.Services.Data
{
    using System.Collections.Generic;

    public interface ITreatmentsService
    {
        IEnumerable<T> GetAll<T>(int id);
    }
}
