using System;
using System.Linq;

namespace TollFeeCalculator
{
    public class TollCalculator : ITollCalculator
    {
        /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total toll fee for that day
         */

        private readonly ITollFreeQualifier TollFreeQualifier;


        public TollCalculator(ITollFreeQualifier tollFreeQualifier) 
            => TollFreeQualifier = tollFreeQualifier;


        //TODO: need to simplify this
        public int GetTollFee(IVehicle vehicle, DateTime[] dates)
        {
            return dates.Aggregate(0, (totalFee, date) =>
                 {
                     int nextFee  = GetTollFee(date, vehicle);
                     int tempFee  = GetTollFee(dates[0], vehicle);
                     long minutes = (date.Millisecond - dates[0].Millisecond) / 1000 / 60;

                     if (minutes > 60)
                     {
                         totalFee += nextFee;
                         return totalFee;
                     }
                     if (totalFee > 0)
                     {
                         totalFee -= tempFee;
                     }
                     if (nextFee >= tempFee) 
                     {
                         tempFee = nextFee;
                     }

                     totalFee += tempFee;
                     return totalFee;
                 }
             ) switch
             {
                 var total when total > 60   => 60,
                 var total when total <= 60  => total
             };
        }


        private int GetTollFee(DateTime date, IVehicle vehicle)
            => TollFreeQualifier.IsTollFree(vehicle, date) switch
            {
                true  => 0,
                false => TollCalculatorFactory.GetTollCalculatorByTimeSlot(date)
            };
    }
}
