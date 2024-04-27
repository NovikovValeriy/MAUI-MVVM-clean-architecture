namespace _253504Novikov.Application.VehicleUseCases.Queries
{
    public sealed record GetVehiclesByGarageRequest(int Id) : IRequest<IEnumerable<Vehicle>>
    {
    }
}
