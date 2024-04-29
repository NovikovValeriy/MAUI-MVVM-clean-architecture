using _253504Novikov.Application.GarageUseCases.Commands.Create;
using _253504Novikov.Application.GarageUseCases.Commands.Update;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _253504Novikov.UI.ViewModels
{
    [QueryProperty(nameof(SelectedGarage), "SelectedGarage")]
    public partial class EditGarageViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private Garage selectedGarage;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private double area;

        [RelayCommand]
        async Task SaveGarage() => SaveNewGarage();

        private async void SaveNewGarage()
        {
            if (Name != String.Empty && Area > 0)
            {
                await _mediator.Send(new EditGarageCommand(SelectedGarage.Id, Name, Area));
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        partial void OnSelectedGarageChanged(Garage value)
        {
            Name = value.Name;
            Area = value.Area;
        }
        public EditGarageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
