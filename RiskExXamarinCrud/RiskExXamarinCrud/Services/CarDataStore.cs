using RiskExXamarinCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiskExXamarinCrud.Services
{
    public class CarDataStore : ICarDataStore<CarItem>
    {
        readonly List<CarItem> cars;

        public CarDataStore()
        {
            cars = new List<CarItem>()
            {
                new CarItem { Id = Guid.NewGuid().ToString(), Car = "Fusca", Manufacturer="VW" },
                new CarItem { Id = Guid.NewGuid().ToString(), Car = "Gol", Manufacturer="VW" },
                new CarItem { Id = Guid.NewGuid().ToString(), Car = "Kombi", Manufacturer="VW" },
                new CarItem { Id = Guid.NewGuid().ToString(), Car = "Voyage", Manufacturer="VW" },
            };
        }

        public async Task<bool> AddCarAsync(CarItem item)
        {
            cars.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCarAsync(CarItem item)
        {
            var oldItem = cars.Where((CarItem arg) => arg.Id == item.Id).FirstOrDefault();
            cars.Remove(oldItem);
            cars.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCarAsync(string id)
        {
            var oldItem = cars.Where((CarItem arg) => arg.Id == id).FirstOrDefault();
            cars.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CarItem> GetCarAsync(string id)
        {
            return await Task.FromResult(cars.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CarItem>> GetCarsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(cars);
        }
    }
}