namespace _253504Novikov.Application.GarageUseCases.Commands.Update
{
    public sealed record EditGarageCommand(int id, string name, double area) : IRequest<Garage>
    {
    }
}
