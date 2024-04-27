namespace _253504Novikov.Domain.Entities
{
    public class Garage : Entity
    {
        private List<Vehicle> _vehicles = new();
        public Garage()
        {

        }

        public Garage(string name, double area)
        {
            Name = name;
            Area = area;
        }

        public string Name { get; private set; }
        public double Area { get; private set; }

        public void ChangeName(string name)
        {
            if(name != string.Empty)
            {
                Name = name;
            }
        }
        public void ChangeArea(double area)
        {
            Area = area;
        }
        public IReadOnlyList<Vehicle> Vehicles { get => _vehicles.AsReadOnly(); }
    }
}
