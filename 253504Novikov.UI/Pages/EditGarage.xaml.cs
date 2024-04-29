using _253504Novikov.UI.ViewModels;

namespace _253504Novikov.UI.Pages;

public partial class EditGarage : ContentPage
{
	EditGarageViewModel _viewModel;
	public EditGarage(EditGarageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}