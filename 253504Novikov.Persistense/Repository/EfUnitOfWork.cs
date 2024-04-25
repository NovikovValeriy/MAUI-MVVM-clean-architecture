using _253504Novikov.Persistense.Data;

namespace _253504Novikov.Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Garage>> _garageRepository;
        private readonly Lazy<IRepository<Vehicle>> _vehicleRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _garageRepository = new Lazy<IRepository<Garage>>(() => new EfRepository<Garage>(context));
            _vehicleRepository = new Lazy<IRepository<Vehicle>>(() => new EfRepository<Vehicle>(context));
        }
        public IRepository<Garage> GarageRepository => _garageRepository.Value;

        public IRepository<Vehicle> VehicleRepository => _vehicleRepository.Value;

        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();

        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();

        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
    }
}
