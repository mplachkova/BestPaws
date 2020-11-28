namespace BestPaws.Services.Data
{
    using System.Collections.Generic;

    public interface IPetCenterService
    {
        IEnumerable<T> GetAll<T>();
    }
}
