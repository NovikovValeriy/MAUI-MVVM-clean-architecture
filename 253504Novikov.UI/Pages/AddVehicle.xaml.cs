using _253504Novikov.UI.ViewModels;

namespace _253504Novikov.UI.Pages;

public partial class AddVehicle : ContentPage
{
	AddVehicleViewModel _viewModel;
	public AddVehicle(AddVehicleViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}