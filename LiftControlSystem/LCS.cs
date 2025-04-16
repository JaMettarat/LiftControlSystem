using LiftControlSystem;
using LiftControlSystem.Utils;

public class LCS
{

    public List<Lift> Lifts { get; set; } = new List<Lift>();

    public void AddLift(Lift lift)
    {
        Lifts.Add(lift);
    }

    public void AddLifts(List<Lift> lifts)
    {
        Lifts.AddRange(lifts);
    }   

    public Lift? CallingLift(Request request)
    {
        if(request == null)
        {
            Console.WriteLine("Request is null");
            return null;
        }            

        var availableLift = Lifts.FirstOrDefault(l =>
            l.ServiceFloors.Contains(request.RequestedFloor) &&
            !l.IsOverload(request.Weight, request.Unit) &&
            l.IsAvailable()
            );

        if (availableLift != null)
        {
            Console.WriteLine($"Assigned Lift: {availableLift.LiftId}");
            availableLift.GoTo(request.RequestedFloor);
        }

        return availableLift;
    }
    public int GetTotalLiftCount()
    {
        return Lifts.Count;
    }
}
