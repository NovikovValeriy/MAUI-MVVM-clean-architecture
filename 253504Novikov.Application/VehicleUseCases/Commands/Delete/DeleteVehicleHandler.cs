
namespace _253504Novikov.Application.VehicleUseCases.Commands.Delete
{
    public class DeleteVehicleHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteVehicleCommand, Vehicle>
    {
        public async Task<Vehicle> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await unitOfWork.VehicleRepository.GetByIdAsync(request.id, cancellationToken);
            await unitOfWork.VehicleRepository.DeleteAsync(vehicle);
            await unitOfWork.SaveAllAsync();
            return vehicle;
        }
    }
}
