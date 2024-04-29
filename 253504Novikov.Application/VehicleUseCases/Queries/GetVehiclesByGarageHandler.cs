using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504Novikov.Application.VehicleUseCases.Queries
{
    public class GetVehiclesByGarageHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetVehiclesByGarageRequest, IEnumerable<Vehicle>>
    {
        public async Task<IEnumerable<Vehicle>> Handle(GetVehiclesByGarageRequest request, CancellationToken cancellationToken)
        {
            var lst = await unitOfWork.VehicleRepository.ListAsync(t => t.GarageId.Equals(request.Id), cancellationToken);
            Debug.WriteLine($"GetVehiclesByGarageHandler Handle {lst.Count}");
            return lst;
        }
    }
}
