namespace _253504Novikov.Application.VehicleUseCases.Commands.Update
{
    public sealed record UpdateVehicleCommand(int id, string name, DateTime inspectionDate, int seatsNumber, int maxWeight, string imageName) : IRequest<Vehicle>
    {
    }
}
