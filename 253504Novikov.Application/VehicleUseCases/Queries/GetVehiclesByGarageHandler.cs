using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504Novikov.Application.VehicleUseCases.Queries
{
    internal class GetVehiclesByGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetVehiclesByGarageRequest, IEnumerable<Vehicle>>
    {
        public async Task<IEnumerable<Vehicle>> Handle(GetVehiclesByGarageRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.VehicleRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
}
