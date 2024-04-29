using System.Diagnostics;
using System.Linq.Expressions;

namespace _253504Novikov.Persistense.Repository
{
    public class FakeGarageRepository : IRepository<Garage>
    {
        List<Garage> _garages;
        public FakeGarageRepository()
        {
            _garages = new List<Garage>();
            var garage = new Garage("Гараж дяди Пети", 40.0);
            garage.Id = 1;
            _garages.Add(garage);

            garage = new Garage("СТО", 240.0);
            garage.Id = 2;
            _garages.Add(garage);
            
            garage = new Garage("Гараж 124", 50.0);
            garage.Id = 3;
            _garages.Add(garage);
        }
        public async Task<IReadOnlyList<Garage>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeGarageRepository ListAllAsync");
            return await Task.Run(() => _garages, cancellationToken);
        }

        public Task AddAsync(Garage entity, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeGarageRepository AddAsync");
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Garage entity, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeGarageRepository DeleteAsync");
            throw new NotImplementedException();
        }

        public Task<Garage> FirstOrDefaultAsync(Expression<Func<Garage, bool>> filter, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeGarageRepository FirstOrDefaultAsync");
            throw new NotImplementedException();
        }

        public Task<Garage> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Garage, object>>[]? includesProperties)
        {
            Debug.WriteLine("FakeGarageRepository GetByIdAsync");
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Garage>> ListAsync(Expression<Func<Garage, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Garage, object>>[]? includesProperties)
        {
            Debug.WriteLine("FakeGarageRepository ListAsync");
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Garage entity, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("FakeGarageRepository UpdateAsync");
            throw new NotImplementedException();
        }
    }
}
