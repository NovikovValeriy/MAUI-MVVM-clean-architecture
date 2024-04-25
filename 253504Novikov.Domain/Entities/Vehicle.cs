namespace _253504Novikov.Domain.Entities
{
    public class Vehicle : Entity
    {
        public Vehicle()
        {
            
        }
        public Vehicle(string name, DateTime inspectionDate, int seatsNumber, int maxWeight)
        {
            Name = name;
            InspectionDate = inspectionDate;
            SeatsNumber = seatsNumber;
            MaxWeight = maxWeight;
        }

        public string Name { get; private set; }
        public DateTime InspectionDate { get; private set; }
        public int SeatsNumber { get; private set; }
        public int MaxWeight { get; private set; }
        public int? GarageId { get; private set; }
        public void AddToGarage(int garageId)
        {
            if (garageId <= 0) return;
            GarageId = garageId;
        }
        public void RemoveFromGarage() => GarageId = 0;

        public void ChangeName(string name)
        {
            if(name != string.Empty) Name = name;
        }
        public void ChangeInspectionDate(DateTime inspectionDate)
        {
            InspectionDate = inspectionDate;
        }
    }
}
