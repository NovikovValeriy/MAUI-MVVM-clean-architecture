using _253504Novikov.Application.GarageUseCases.Commands.Update;
using _253504Novikov.Application.VehicleUseCases.Commands.Create;
using _253504Novikov.Application.VehicleUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _253504Novikov.UI.ViewModels
{
    [QueryProperty(nameof(SelectedGarage), "SelectedGarage")]
    public partial class AddVehicleViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Garage selectedGarage;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private DateTime isnpectionDate = DateTime.Today;

        [ObservableProperty]
        private int seatsNumber;

        [ObservableProperty]
        private int maxWeight;

        [ObservableProperty]
        private string imageName = "dotnet_bot.png";

        [RelayCommand]
        async Task SaveNewVehicle() => await SaveVehicle();

        [RelayCommand]
        async Task AddVehicleImage() => await AddImage();

        private async Task AddImage()
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
                    ImageName = result.FullPath;
                    OnPropertyChanged(nameof(ImageName));
                }
            }
        }

        private async Task SaveVehicle()
        {
            if (Name != string.Empty && SeatsNumber > 0 && MaxWeight >= 0)
            {
                await _mediator.Send(new AddVehicleToGarageCommand(Name, IsnpectionDate, SeatsNumber, MaxWeight, SelectedGarage.Id, ImageName));
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        public AddVehicleViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
