using LiftControlSystem;
using LiftControlSystem.DerivedClass;


#region 2.Implement LCS at ABC Building
var liftControlSystem = new LCS();

// Low Zone
liftControlSystem.AddLifts(new List<Lift>
{
    new Lift(1, "A", "A1", "Low", Enumerable.Range(1, 10).ToList(), 1000, 1),
    new Lift(2, "A", "A2", "Low", Enumerable.Range(1, 10).ToList(), 1000, 1)
});

// Medium Zone
liftControlSystem.AddLifts(new List<Lift>
{
    new Lift(3, "B", "B3", "Medium", Enumerable.Range(11, 20).ToList(), 1500, 25),
    new Lift(4, "B", "B4", "Medium", Enumerable.Range(11, 20).ToList(), 1500, 25)
});

// High Zone
liftControlSystem.AddLifts(new List<Lift>
{
    new Lift(5, "C", "C5", "High", Enumerable.Range(31, 20).ToList(), 2000, 40),
    new Lift(6, "C", "C6", "High", Enumerable.Range(31, 20).ToList(), 2000, 40)
});
#endregion

#region Calling lift name "A1" go to mantainance
Console.WriteLine($"Lift A1 go to maintenance");
liftControlSystem.Lifts.FirstOrDefault(l => l.Name == "A1")?.GoToMaintenance();
Console.WriteLine();
#endregion


#region Calling lift to floor 8 with weight 180 Kg
var request1 = new Request
{
    RequestedFloor = 8,
    Direction = Direction.Up,
    Weight = 180
};
liftControlSystem.CallingLift(request1);
Console.WriteLine();
#endregion


#region 3.1. Enable LCS to receive value from Lift Weight Sensor in “lb” or “pound” where 1 Kg = 2.2 lb. Thus “Overload Checking” function can be support for both “Kg” and “lb”
var request2 = new Request
{
    RequestedFloor = 20,
    Direction = Direction.Up,
    Weight = 3300,
    Unit = WeightUnit.lb
};
liftControlSystem.CallingLift(request2);
Console.WriteLine();
#endregion


#region 3.2. Enable LCS to ignore lift calling if it is running at full load 
var lift1 = new Lift(1, "A", "A5", "Low", Enumerable.Range(1, 10).ToList(), 1000, 1);
lift1.UpdateWeight(1000);
//Add method IsAvailable to check if lift is full load or not
lift1.IsAvailable();
#endregion

#region 3.3. Enable LCS to count the total number of lifts in the system. 
int totalLifts = liftControlSystem.GetTotalLiftCount();
Console.WriteLine($"Total Lifts in the system: {totalLifts}");
Console.WriteLine();
#endregion


#region Add Subclass ServiceLift
var serviceLiftControlSystem = new LCS();
serviceLiftControlSystem.AddLift(new SepacialLift(1, "A", "service1", "Low", Enumerable.Range(1, 10).ToList(), 1000, 1));
var requestServiceLift = new Request
{
    RequestedFloor = 5,
    Direction = Direction.Up,
    Weight = 900
};
serviceLiftControlSystem.CallingLift(requestServiceLift);
Console.WriteLine();
#endregion


#region Add Subclass SpecialLift
var specialLiftControlSystem = new LCS();
specialLiftControlSystem.AddLift(new ServiceLift(1, "A", "specail1", "Low", Enumerable.Range(1, 10).ToList(), 1000, 1));
var requestSpecialLift = new Request
{
    RequestedFloor = 9,
    Direction = Direction.Up,
    Weight = 1020
};
specialLiftControlSystem.CallingLift(requestSpecialLift);
Console.WriteLine();
#endregion




