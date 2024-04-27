
namespace _253504Novikov.Application.GarageUseCases.Commands.Update
{
    public class EditGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditGarageCommand, Garage>
    {
        public async Task<Garage> Handle(EditGarageCommand request, CancellationToken cancellationToken)
        {
            var garage = await unitOfWork.GarageRepository.GetByIdAsync(request.id);
            garage.ChangeName(request.name);
            garage.ChangeArea(request.area);
            await unitOfWork.SaveAllAsync();
            return garage;
        }
    }
}
