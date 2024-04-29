using _253504Novikov.Application.GarageUseCases.Commands.Create;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504Novikov.UI.ViewModels
{
    public partial class AddGarageViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private double area;

        [ObservableProperty]
        private int id;

        [RelayCommand]
        async Task SaveGarage() => SaveNewGarage();

        private async void SaveNewGarage()
        {
            if(Name != String.Empty && Area > 0 && Id > 0)
            {
                var garage = _mediator.Send(new AddGarageCommand(Name, Area, Id));
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }

        public AddGarageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
