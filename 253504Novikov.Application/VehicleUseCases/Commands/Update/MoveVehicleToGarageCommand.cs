namespace _253504Novikov.Application.VehicleUseCases.Commands.Update
{
    public sealed record MoveVehicleToGarageCommand(int vehicleId, int garageId) : IRequest<Vehicle>
    {
    }
}
