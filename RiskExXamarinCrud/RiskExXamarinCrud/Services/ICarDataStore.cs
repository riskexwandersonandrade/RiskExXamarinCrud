using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiskExXamarinCrud.Services
{
    public interface ICarDataStore<T>
    {
        Task<bool> AddCarAsync(T car);
        Task<bool> UpdateCarAsync(T car);
        Task<bool> DeleteCarAsync(string id);
        Task<T> GetCarAsync(string id);
        Task<IEnumerable<T>> GetCarsAsync(bool forceRefresh = false);
    }
}
