using LiftControlSystem.Utils;

namespace LiftControlSystem.DerivedClass
{
    public class ServiceLift : Lift
    {
        public ServiceLift(int id, string type, string name, string zone, List<int> floors, double maxWeightKg, int parking)
            : base(id, type, name, zone, floors, maxWeightKg, parking)
        {
        }

        //เพิ่มความสามารถพิเศษให้กับ ServiceLift ให้รับน้ำหนักได้มากขึ้น 2% และเพิ่ม sealed method เพื่อให้ subclass ไม่สามารถ override method IsOverload ได้
        public sealed override bool IsOverload(double weight, WeightUnit unit = WeightUnit.Kg)
        {
            var weightKg = weight;
            if (unit == WeightUnit.lb)
                weightKg = GeneralHelper.LbToKg(weight);

            return weightKg > (MaxWeightKg * 102 / 100);
        }
    }
}
