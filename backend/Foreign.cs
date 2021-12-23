namespace TollFeeCalculator
{
    public class Foreign : IVehicle
    {
        public TollFreeVehicles GetVehicleType() => TollFreeVehicles.Foreign;
    }

}