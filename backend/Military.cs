namespace TollFeeCalculator
{
    public class Military : IVehicle
    {
        public TollFreeVehicles GetVehicleType() => TollFreeVehicles.Military;
    }

}