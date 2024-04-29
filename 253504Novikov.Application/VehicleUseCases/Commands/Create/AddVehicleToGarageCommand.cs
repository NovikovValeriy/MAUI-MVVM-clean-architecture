namespace _253504Novikov.Application.VehicleUseCases.Commands.Create
{
    public sealed record AddVehicleToGarageCommand(string name, DateTime inspectionDate, int seatsNumber, int maxWeight, int garageId, string imageFile = "dotnet_bot.png") : IRequest<Vehicle>
    {
    }
}
