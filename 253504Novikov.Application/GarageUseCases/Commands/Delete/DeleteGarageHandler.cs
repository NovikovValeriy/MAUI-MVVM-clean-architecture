
namespace _253504Novikov.Application.GarageUseCases.Commands.Delete
{
    public class DeleteGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteGarageCommand, Garage>
    {
        public async Task<Garage> Handle(DeleteGarageCommand request, CancellationToken cancellationToken)
        {
            var garage = await unitOfWork.GarageRepository.GetByIdAsync(request.id, cancellationToken);
            await unitOfWork.GarageRepository.DeleteAsync(garage, cancellationToken);

            var vehicleList = await unitOfWork.VehicleRepository.ListAsync(t => t.GarageId == request.id, cancellationToken);
            foreach (var vehicle in vehicleList)
            {
                await unitOfWork.VehicleRepository.DeleteAsync(vehicle, cancellationToken);
            }

            await unitOfWork.SaveAllAsync();
            return garage;
        }
    }
}
