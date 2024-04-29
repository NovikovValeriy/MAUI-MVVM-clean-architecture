using _253504Novikov.UI.ViewModels;

namespace _253504Novikov.UI.Pages;

public partial class AddGarage : ContentPage
{
	AddGarageViewModel _viewModel;
	public AddGarage(AddGarageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}