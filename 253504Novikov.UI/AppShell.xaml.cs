using _253504Novikov.UI.Pages;

namespace _253504Novikov.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VehicleDetails), typeof(VehicleDetails));
            Routing.RegisterRoute(nameof(AddGarage), typeof(AddGarage));
            Routing.RegisterRoute(nameof(EditGarage), typeof(EditGarage));
            Routing.RegisterRoute(nameof(AddVehicle), typeof(AddVehicle));
            Routing.RegisterRoute(nameof(EditVehicle), typeof(EditVehicle));
        }
    }
}
