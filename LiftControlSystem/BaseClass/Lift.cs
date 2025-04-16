using LiftControlSystem.Utils;

namespace LiftControlSystem
{
    public class Lift
    {
        public int LiftId { get; set; }        
        public string LiftType { get; set; }
        public string Name { get; set; }
        public string Zone { get; set; }
        public List<int> ServiceFloors { get; set; }
        public double MaxWeightKg { get; set; }
        public int ParkingFloor { get; set; }
        public Direction CurrentDirection { get; set; }

        private double currentWeightKg;
        public double CurrentWeightKg { get => currentWeightKg; }

        public Lift(int id, string type, string name, string zone, List<int> floors, double maxWeightKg, int parking)
        {
            LiftId = id;
            LiftType = type;
            Name = name;
            Zone = zone;
            ServiceFloors = floors;
            MaxWeightKg = maxWeightKg;
            ParkingFloor = parking;
        }

        public void UpdateWeight(double weight, WeightUnit unit = WeightUnit.Kg)
        {
            var weightKg = weight;
            if (unit == WeightUnit.lb)
                weightKg = GeneralHelper.LbToKg(weight);

            currentWeightKg += weightKg;
        }

        public virtual void GoTo(int floor)
        {
            if (ServiceFloors.Contains(floor))
                Console.WriteLine($"Lift {LiftId} moving to floor {floor}");
            else
                Console.WriteLine($"Lift {LiftId} cannot go to floor {floor}");
        }

        public virtual bool IsOverload(double weight, WeightUnit unit = WeightUnit.Kg)
        {
            var weightKg = weight;
            if (unit == WeightUnit.lb)
                weightKg = GeneralHelper.LbToKg(weight);

            return weightKg > MaxWeightKg;
        }

        public void GoToMaintenance()
        {
            GoTo(ParkingFloor);
            CurrentDirection = Direction.Parking;
        }
        public virtual bool IsAvailable()
        {
            return CurrentWeightKg < MaxWeightKg;
        }       
    }
}
