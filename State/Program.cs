using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new StateA());
            context.Request(); // Переход в состояние StateB
            context.Request();  // Переход в состояние StateA

            WaterNoState waterNoState = new WaterNoState(WaterState.LIQUID);
            waterNoState.Heat();
            waterNoState.Frost();
            waterNoState.Frost();

            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();
        }
    }
}
