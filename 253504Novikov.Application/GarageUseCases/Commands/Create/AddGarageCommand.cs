namespace _253504Novikov.Application.GarageUseCases.Commands.Create
{
    public sealed record AddGarageCommand(string name, double area) : IRequest<Garage>
    {
    }
}
