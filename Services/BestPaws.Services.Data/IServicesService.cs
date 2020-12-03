namespace BestPaws.Services.Data
{
    using System.Collections.Generic;

    public interface IServicesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
