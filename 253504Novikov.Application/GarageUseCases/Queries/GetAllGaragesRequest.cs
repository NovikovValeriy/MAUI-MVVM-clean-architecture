namespace _253504Novikov.Application.GarageUseCases.Queries
{
    public sealed record GetAllGaragesRequest() : IRequest<IEnumerable<Garage>>
    {
    }
}
