using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculator
{
    public class TollCalculator : ITollCalculator
    {

        const int maxFee = 60;
        private readonly ICanCalculateTollByDate calculatorByDate;
        private readonly ICanResolveIfTollFree tollFreeQualifier;

        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */



        public TollCalculator(ICanCalculateTollByDate calculatorByDate, ICanResolveIfTollFree tollFreeQualifier)
        {
            this.calculatorByDate  = calculatorByDate;
            this.tollFreeQualifier = tollFreeQualifier;

        }


        //TODO: still need to simplify this
        public int GetTollFee(IVechicleType vehicle, List<DateTime> dates)
        {
            if (tollFreeQualifier.IsTollFreeVehicle(vehicle)) 
            {
                return 0;
            }
            int total = dates.OrderBy(d => d)
                             .Aggregate(0, (totalFee, date) =>
                             {
                                 if (tollFreeQualifier.IsTollFreeDate(date))
                                 {
                                     return totalFee;
                                 }

                                 int nextFee      = calculatorByDate.TollCalculatorByDate(date);
                                 int feeFromStart = calculatorByDate.TollCalculatorByDate(dates[0]);
                                 long minutes = (date.Millisecond - dates[0].Millisecond) / 1000 / 60;

                                 if (minutes > 60)
                                 {
                                     totalFee += nextFee;
                                     return totalFee;
                                 }
                                 if (totalFee > 0)
                                 {
                                     totalFee -= feeFromStart;
                                 }
                                 if (nextFee >= feeFromStart)
                                 {
                                     feeFromStart = nextFee;
                                 }

                                 totalFee += feeFromStart;
                                 return totalFee;
                             }); 

            return total switch
            {
                > maxFee => maxFee,
                _        => total
            };
        }
    }
}
