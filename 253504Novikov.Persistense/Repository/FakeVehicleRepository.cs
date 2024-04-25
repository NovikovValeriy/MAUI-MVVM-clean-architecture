using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            for (int i = 1; i <= 2; i++)
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
            return await query.Where(filter).ToListAsync(cancellationToken);
        }
        public Task AddAsync(Vehicle entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Vehicle entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> FirstOrDefaultAsync(Expression<Func<Vehicle, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Vehicle, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Vehicle>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vehicle entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
