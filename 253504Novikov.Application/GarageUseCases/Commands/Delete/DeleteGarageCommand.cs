namespace _253504Novikov.Application.GarageUseCases.Commands.Delete
{
    public sealed record DeleteGarageCommand(int id) : IRequest<Garage>
    {
    }
}
