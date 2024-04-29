
namespace _253504Novikov.Application.VehicleUseCases.Commands.Create
{
    public class AddVehicleToGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddVehicleToGarageCommand, Vehicle>
    {
        public async Task<Vehicle> Handle(AddVehicleToGarageCommand request, CancellationToken cancellationToken)
        {

            Vehicle vehicle = new Vehicle(request.name, request.inspectionDate, request.seatsNumber, request.maxWeight, request.imageFile);
            vehicle.AddToGarage(request.garageId);
            await unitOfWork.VehicleRepository.AddAsync(vehicle, cancellationToken);
            await unitOfWork.SaveAllAsync();
            return vehicle;
        }
    }
}
