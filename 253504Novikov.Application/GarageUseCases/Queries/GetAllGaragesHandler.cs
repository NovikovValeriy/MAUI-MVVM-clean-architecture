
namespace _253504Novikov.Application.GarageUseCases.Queries
{
    public class GetAllGaragesHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllGaragesRequest, IEnumerable<Garage>>
    {
        public async Task<IEnumerable<Garage>> Handle(GetAllGaragesRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.GarageRepository.ListAllAsync(cancellationToken);
        }
    }
}
