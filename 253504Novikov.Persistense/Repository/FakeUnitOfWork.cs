
namespace _253504Novikov.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Garage> _garageRepository;
        private readonly IRepository<Vehicle> _vehicleRepository;
        public FakeUnitOfWork()
        {
            _garageRepository = new FakeGarageRepository();
            _vehicleRepository = new FakeVehicleRepository();
        }

        public IRepository<Garage> GarageRepository => _garageRepository;

        public IRepository<Vehicle> VehicleRepository => _vehicleRepository;

        public Task CreateDataBaseAsync()
        {
            return Task.CompletedTask;
        }

        public Task DeleteDataBaseAsync()
        {
            return Task.CompletedTask;
        }

        public Task SaveAllAsync()
        {
            return Task.CompletedTask;
        }
    }
}
