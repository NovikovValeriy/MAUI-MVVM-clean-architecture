namespace _253504Novikov.Application.VehicleUseCases.Commands.Delete
{
    public sealed record DeleteVehicleCommand(int id) : IRequest<Vehicle>
    {
    }
}
