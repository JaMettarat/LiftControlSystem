namespace LiftControlSystem
{
    public class Request
    {
        public int RequestedFloor { get; set; }
        public Direction Direction { get; set; }
        public double Weight { get; set; }
        public WeightUnit Unit { get; set; } = WeightUnit.Kg;// default is Kg
    }
}
