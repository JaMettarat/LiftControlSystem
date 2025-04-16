namespace LiftControlSystem.DerivedClass
{
    //เพิ่ม sealed class PassengerLift เพื่อไม่ให้ subclass อื่นๆ สามารถสืบทอดจาก PassengerLift ได้
    public sealed class SepacialLift : Lift
    {
        public SepacialLift(int id, string type, string name, string zone, List<int> floors, double maxWeightKg, int parking)
            : base(id, type, name, zone, floors, maxWeightKg, parking)
        {
        }

        //เพิ่มความสามารถพิเศษให้กับ PassengerLift ให้แสดงข้อความเพิ่มเติมเมื่อมีการเรียกใช้ method GoTo
        public override void GoTo(int floor)
        {
            if (ServiceFloors.Contains(floor))
                Console.WriteLine($"Sepacial Lift {LiftId} moving to floor {floor}");
            else
                Console.WriteLine($"Sepacial Lift {LiftId} cannot go to floor {floor}");
        }
    }
}
