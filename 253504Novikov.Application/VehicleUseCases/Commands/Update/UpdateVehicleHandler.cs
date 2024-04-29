
namespace _253504Novikov.Application.VehicleUseCases.Commands.Update
{
    public class UpdateVehicleHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateVehicleCommand, Vehicle>
    {
        public async Task<Vehicle> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await unitOfWork.VehicleRepository.GetByIdAsync(request.id);
            vehicle.ChangeName(request.name);
            vehicle.ChangeInspectionDate(request.inspectionDate);
            vehicle.ChangeMaxWeight(request.maxWeight);
            vehicle.ChangeSeatsNumber(request.seatsNumber);
            vehicle.ChangePictureName(request.imageName);
            await unitOfWork.VehicleRepository.UpdateAsync(vehicle);
            await unitOfWork.SaveAllAsync();
            return vehicle;
        }
    }
}
