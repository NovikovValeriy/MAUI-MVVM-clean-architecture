using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253504Novikov.Persistense.Repository
{
    public class FakeVehicleRepository : IRepository<Vehicle>
    {
        List<Vehicle> _vehicles;
        public FakeVehicleRepository()
        {
            _vehicles = new List<Vehicle>();
            int k = 1;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var vehicle = new Vehicle($"{k++}", DateTime.Now, 4, 1200);
                    vehicle.AddToGarage(i);
                    _vehicles.Add(vehicle);
                }
            }
        }

        public async Task<IReadOnlyList<Vehicle>> ListAsync(Expression<Func<Vehicle, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Vehicle, object>>[]? includesProperties)
        {
            var query = _vehicles.AsQueryable();
            Debug.WriteLine("FakeVehicleRepository ListAsync");
            //var lst2 = query.Where(filter).ToListAsync(); //ToListAsync() throws an exception, use ToList()
            var lst = _vehicles.Where(filter.Compile()).ToList();
            Debug.WriteLine($"FakeVehicleRepository ListAsync list : {lst.Count}");
            return lst;
        }
        public Task AddAsync(Vehicle entity, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeVehicleRepository AddAsync");
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Vehicle entity, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeVehicleRepository DeleteAsync");
            throw new NotImplementedException();
        }

        public Task<Vehicle> FirstOrDefaultAsync(Expression<Func<Vehicle, bool>> filter, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeVehicleRepository FirstOrDefaultAsync");
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Vehicle, object>>[]? includesProperties)
        {
            Debug.WriteLine("FakeVehicleRepository GetByIdAsync");
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Vehicle>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeVehicleRepository ListAllAsync");
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vehicle entity, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeVehicleRepository UpdateAsync");
            throw new NotImplementedException();
        }
    }
}
