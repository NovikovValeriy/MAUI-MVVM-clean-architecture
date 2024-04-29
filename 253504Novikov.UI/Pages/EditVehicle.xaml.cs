using _253504Novikov.UI.ViewModels;

namespace _253504Novikov.UI.Pages;

public partial class EditVehicle : ContentPage
{
	EditVehicleViewModel _viewModel;
	public EditVehicle(EditVehicleViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}