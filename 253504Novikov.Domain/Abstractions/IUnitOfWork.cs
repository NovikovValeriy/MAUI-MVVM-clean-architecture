using _253504Novikov.Domain.Entities;

namespace _253504Novikov.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Garage> GarageRepository { get; }
        IRepository<Vehicle> VehicleRepository { get; }

        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
