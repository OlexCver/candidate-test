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


        //TODO: still need to refactor this as it seems wrong calculation
        public int GetTollFee(IVechicleType vehicle, List<DateTime> dates)
        {
            if (tollFreeQualifier.IsTollFreeVehicle(vehicle) || !dates.Any()) 
            {
                return 0;
            }
            var orderedDates = dates.OrderBy(d => d)
                                    .ToList();

            var previousDate = orderedDates[0];
            var previousFee = calculatorByDate.TollCalculatorByDate(previousDate);

            int total = orderedDates.Aggregate(0, (totalFee, date) =>
                        {
                            if (tollFreeQualifier.IsTollFreeDate(date))
                            {
                                previousDate = date;
                                previousFee  = 0;
                                return totalFee;
                            }

                            var nextFee   = calculatorByDate.TollCalculatorByDate(date);
                            var minutes   = (date - previousDate).TotalMinutes;
                            totalFee += (minutes > 60) switch 
                            { 
                                true                      => nextFee,
                                false when (totalFee > 0) => Math.Max(nextFee, previousFee) - previousFee,
                                _                         => Math.Max(nextFee, previousFee),
                            };

                            previousDate = date;
                            previousFee  = nextFee;

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
