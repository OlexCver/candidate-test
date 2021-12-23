using System;

namespace TollFeeCalculator
{
    public interface ITollFreeQualifier 
    {
        public bool IsTollFree(IVehicle vehicle, DateTime date);
    }

}