
namespace _253504Novikov.Application.VehicleUseCases.Commands.Create
{
    public class AddVehicleToGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddVehicleToGarageCommand, Vehicle>
    {
        public async Task<Vehicle> Handle(AddVehicleToGarageCommand request, CancellationToken cancellationToken)
        {
            Vehicle vehicle = new Vehicle(request.name, request.inspectionDate, request.seatsNumber, request.maxWeight);
            await unitOfWork.VehicleRepository.AddAsync(vehicle, cancellationToken);
            await unitOfWork.SaveAllAsync();
            return vehicle;
        }
    }
}
