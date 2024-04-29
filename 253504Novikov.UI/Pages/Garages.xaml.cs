using _253504Novikov.UI.ViewModels;

namespace _253504Novikov.UI.Pages;

public partial class Garages : ContentPage
{
	GaragesViewModel _viewmodel;
	public Garages(GaragesViewModel viewModel)
	{
		InitializeComponent();
        _viewmodel = viewModel;
		BindingContext = _viewmodel;
    }
}