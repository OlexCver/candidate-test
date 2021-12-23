using System;
using System.Linq;

namespace TollFeeCalculator
{

    public class ResolverIfTollFree : ICanResolveIfTollFree
    {

        public bool IsTollFreeVehicle(IVechicleType vehicle) 
            => TollFreeQualifierFactory.GetFreeTollList
                                       .Any(noPay => vehicle.GetVehicleType.Equals(noPay));

        public bool IsTollFreeDate(DateTime date)
            => TollCalculatorFactory.GetFreeToolDatesQualifier(date);

    }



}