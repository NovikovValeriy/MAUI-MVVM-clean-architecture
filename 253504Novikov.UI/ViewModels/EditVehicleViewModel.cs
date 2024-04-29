using _253504Novikov.Application.VehicleUseCases.Commands.Update;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _253504Novikov.UI.ViewModels
{
    [QueryProperty(nameof(SelectedVehicle), "SelectedVehicle")]
    public partial class EditVehicleViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Vehicle selectedVehicle;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private DateTime inspectionDate;
        
        [ObservableProperty]
        private int maxWeight;
        
        [ObservableProperty]
        private int seatsNumber;
        
        [ObservableProperty]
        private string imageName;

        [RelayCommand]
        async Task EditVehicleImage() => EditImage();

        [RelayCommand]
        async Task SaveVehicle() => SaveVehicleHandler();

        private async void SaveVehicleHandler()
        {
            if (Name != string.Empty && SeatsNumber > 0 && MaxWeight >= 0)
            {
                await _mediator.Send(new UpdateVehicleCommand(SelectedVehicle.Id, Name, InspectionDate, SeatsNumber, MaxWeight, ImageName));
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async void EditImage()
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

        partial void OnSelectedVehicleChanged(Vehicle value)
        {
            Name = value.Name;
            InspectionDate = value.InspectionDate;
            MaxWeight = value.MaxWeight;
            SeatsNumber = value.SeatsNumber;
            ImageName = value.ImageFile;
        }
        public EditVehicleViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
