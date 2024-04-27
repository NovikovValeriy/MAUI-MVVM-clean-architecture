
namespace _253504Novikov.Application.VehicleUseCases.Commands.Update
{
    public class MoveVehicleToGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<MoveVehicleToGarageCommand, Vehicle>
    {
        public async Task<Vehicle> Handle(MoveVehicleToGarageCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await unitOfWork.VehicleRepository.GetByIdAsync(request.vehicleId);
            vehicle.AddToGarage(request.vehicleId);
            await unitOfWork.VehicleRepository.UpdateAsync(vehicle);
            await unitOfWork.SaveAllAsync();
            return vehicle;
        }
    }
}
