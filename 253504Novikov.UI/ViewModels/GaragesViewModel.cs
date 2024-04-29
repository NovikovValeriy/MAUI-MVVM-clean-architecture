using _253504Novikov.Application.GarageUseCases.Commands.Delete;
using _253504Novikov.Application.GarageUseCases.Queries;
using _253504Novikov.Application.VehicleUseCases.Queries;
using _253504Novikov.Domain.Entities;
using _253504Novikov.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _253504Novikov.UI.ViewModels
{
    public partial class GaragesViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public GaragesViewModel(IMediator mediator)
        {
            GetGarages();
            _mediator = mediator;
        }

        public ObservableCollection<Garage> Garages { get; set; } = new();
        public ObservableCollection<Vehicle> Vehicles { get; set; } = new();

        [ObservableProperty]
        Garage selectedGarage;

        [RelayCommand]
        async Task UpdateGaragesList() => await GetGarages();
        
        [RelayCommand]
        async Task UpdateVehiclesList() => await GetVehicles();

        [RelayCommand]
        async void ShowDetails(Vehicle vehicle) => await GotoDetailsPage(vehicle);

        [RelayCommand]
        async void AddGarage() => await GotoGarageAddPage();

        [RelayCommand]
        async void EditGarage(Garage garage) => await GotoGarageEditPage(garage);

        [RelayCommand]
        async void DeleteGarage(Garage garage) => await GarageDeletion(garage);

        [RelayCommand]
        async void AddVehicle(Garage garage) => await VehicleCreation(garage);

        private async Task VehicleCreation(Garage garage)
        {
            if (garage == null) return;
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"SelectedGarage", garage }
            };
            await Shell.Current.GoToAsync(nameof(_253504Novikov.UI.Pages.AddVehicle), parameters);
        }

        private async Task GarageDeletion(Garage garage)
        {
            if(garage == null) return;
            await _mediator.Send(new DeleteGarageCommand(garage.Id));
            await GetGarages();
        }

        private async Task GotoGarageEditPage(Garage garage)
        {
            if(garage == null) return;
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"SelectedGarage", garage }
            };
            await Shell.Current.GoToAsync(nameof(_253504Novikov.UI.Pages.EditGarage), parameters);
        }

        private async Task GotoGarageAddPage()
        {
            await Shell.Current.GoToAsync(nameof(AddGarage));
        }

        private async Task GotoDetailsPage(Vehicle vehicle)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"SelectedVehicle", vehicle }
            };
            await Shell.Current.GoToAsync(nameof(VehicleDetails), parameters);
        }

        public async Task GetGarages()
        {
            var garages = await _mediator.Send(new GetAllGaragesRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Garages.Clear();
                foreach (var garage in garages)
                {
                    Garages.Add(garage);
                }
            });
        }

        public async Task GetVehicles()
        {
            if (SelectedGarage == null)
            {
                Vehicles.Clear();
                return;
            }
            var vehicles = await _mediator.Send(new GetVehiclesByGarageRequest(SelectedGarage.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Vehicles.Clear();
                foreach (var vehicle in vehicles)
                {
                    Vehicles.Add(vehicle);
                }
            });
        }
    }
}
