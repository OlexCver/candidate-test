namespace TollFeeCalculator
{
    public class Emergency : IVehicle
    {
        public TollFreeVehicles GetVehicleType() => TollFreeVehicles.Emergency;
    }

}