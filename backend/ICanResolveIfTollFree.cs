using System;

namespace TollFeeCalculator
{
    public interface ICanResolveIfTollFree 
    {

        public bool IsTollFreeVehicle(IVechicleType vehicle);

        public bool IsTollFreeDate(DateTime date);
    }

}