using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace _253504Novikov.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            var garage1 = new Garage("СТО \"скажи спасибо что не отпиздили\"", 250.0);
            garage1.Id = 1;
            var garage2 = new Garage("Гараж 69", 50.0);
            garage2.Id = 2;
            var garage3 = new Garage("Склад Wildberries", 1000.0);
            garage3.Id = 3;

            await unitOfWork.GarageRepository.AddAsync(garage1);
            await unitOfWork.GarageRepository.AddAsync(garage2);
            await unitOfWork.GarageRepository.AddAsync(garage3);
            await unitOfWork.SaveAllAsync();

            int j = 1;
            var vehicle11 = new Vehicle("Lada Vesta", DateTime.Now.AddYears(-1).AddDays(-1), 5, 1200);
            vehicle11.Id = j++;
            vehicle11.AddToGarage(garage1.Id);
            await unitOfWork.VehicleRepository.AddAsync(vehicle11);

            var vehicle12 = new Vehicle("Ford Focus", DateTime.Now.AddMonths(-1), 5, 1400);
            vehicle12.Id = j++;
            vehicle12.AddToGarage(garage1.Id);
            await unitOfWork.VehicleRepository.AddAsync(vehicle12);

            var vehicle13 = new Vehicle("Daewoo Matiz", DateTime.Now.AddYears(-5), 5, 800);
            vehicle13.Id = j++;
            vehicle13.AddToGarage(garage1.Id);
            await unitOfWork.VehicleRepository.AddAsync(vehicle13);

            var vehicle14 = new Vehicle("BMW e34", DateTime.Now.AddDays(-12), 5, 1100);
            vehicle14.Id = j++;
            vehicle14.AddToGarage(garage1.Id);
            await unitOfWork.VehicleRepository.AddAsync(vehicle14);

            for (int i = 1; i <= 10; i++)
            {
                var vehicle = new Vehicle($"Vehicle {i}", DateTime.Now.AddMonths(i * (-1)), 7, 2000);
                vehicle.Id = j++;
                vehicle.AddToGarage(garage2.Id);
                await unitOfWork.VehicleRepository.AddAsync(vehicle);
            }

            for (int i = 11; i <= 20; i++)
            {
                var vehicle = new Vehicle($"Vehicle {i}", DateTime.Now.AddMonths(i * (-1)), 7, 2000);
                vehicle.Id = j++;
                vehicle.AddToGarage(garage3.Id);
                await unitOfWork.VehicleRepository.AddAsync(vehicle);
            }

            await unitOfWork.SaveAllAsync();
        }
    }
}
