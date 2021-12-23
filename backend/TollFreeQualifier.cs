
using System;
using System.Linq;

namespace TollFeeCalculator
{

    public class TollFreeQualifier: ITollFreeQualifier
    {
        public bool IsTollFree(IVehicle vehicle, DateTime date)
            => IsTollFreeVehicle(vehicle) || IsTollFreeDate(date);

        private bool IsTollFreeVehicle(IVehicle vehicle) 
            => TollFreeQualifierFactory.GetFreeToolList
                                       .Any(noPay => vehicle != null && 
                                                     vehicle.GetVehicleType().Equals(noPay));

        private bool IsTollFreeDate(DateTime date)
            => TollFreeQualifierFactory.GetFreeToolDatesQualifier(date);

    }

}