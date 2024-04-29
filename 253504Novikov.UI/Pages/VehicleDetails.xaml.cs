using _253504Novikov.UI.ViewModels;

namespace _253504Novikov.UI.Pages;

public partial class VehicleDetails : ContentPage
{
	VehicleDetailsViewModel _viewModel;
	public VehicleDetails(VehicleDetailsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = _viewModel;
	}
}