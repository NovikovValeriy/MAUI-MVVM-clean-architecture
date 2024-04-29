using _253504Novikov.Application.VehicleUseCases.Commands.Delete;
using _253504Novikov.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace _253504Novikov.UI.ViewModels
{
    [QueryProperty(nameof(SelectedVehicle), "SelectedVehicle")]
    public partial class VehicleDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Vehicle selectedVehicle;

        [RelayCommand]
        async Task EditVehicle(Vehicle vehicle) => GotoEditVehicle(vehicle);

        private async void GotoEditVehicle(Vehicle vehicle)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"SelectedVehicle", vehicle }
            };
            await Shell.Current.GoToAsync(nameof(_253504Novikov.UI.Pages.EditVehicle), parameters);
        }

        [RelayCommand]
        async Task ChangePicture() => ChangePictureHandler();

        [RelayCommand]
        async Task Update() => UpdateHandler();

        [RelayCommand]
        async Task DeleteVehicle() => Delete();

        private async void Delete()
        {
            await _mediator.Send(new DeleteVehicleCommand(SelectedVehicle.Id));
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void UpdateHandler()
        {
            OnPropertyChanged(nameof(SelectedVehicle));
        }

        private async void ChangePictureHandler()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Choose the Image"
                });

                if (result != null)
                {
                    SelectedVehicle.ChangePictureName(result.FullPath);
                    OnPropertyChanged(nameof(SelectedVehicle));
                }
            }
        }

        public VehicleDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
