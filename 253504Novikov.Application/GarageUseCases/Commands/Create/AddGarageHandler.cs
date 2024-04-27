namespace _253504Novikov.Application.GarageUseCases.Commands.Create
{
    public class AddGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddGarageCommand, Garage>
    {
        public async Task<Garage> Handle(AddGarageCommand request, CancellationToken cancellationToken)
        {
            var garage = new Garage(request.name, request.area);
            await unitOfWork.GarageRepository.AddAsync(garage, cancellationToken);
            await unitOfWork.SaveAllAsync();
            return garage;
        }
    }
}
