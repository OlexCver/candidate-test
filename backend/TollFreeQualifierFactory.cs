
using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public static class TollFreeQualifierFactory 
    {
        public static List<TollFreeVehicles> GetFreeToolList => new List<TollFreeVehicles>()
        {
            { TollFreeVehicles.Motorbike },
            { TollFreeVehicles.Tractor },
            { TollFreeVehicles.Emergency },
            { TollFreeVehicles.Diplomat },
            { TollFreeVehicles.Foreign },
            { TollFreeVehicles.Military },
        };

        public static Func<DateTime, bool> GetFreeToolDatesQualifier
            => (date) =>
            {
                int year  = date.Year;
                int month = date.Month;
                int day   = date.Day;

                return date.DayOfWeek switch
                {
                    DayOfWeek.Saturday  => true,
                    DayOfWeek.Sunday    => true,

                    _ when ((year == 2013) &&
                           (month == 1 && day == 1 ||
                            month == 3 && (day == 28 || day == 29) ||
                            month == 4 && (day == 1 || day == 30) ||
                            month == 5 && (day == 1 || day == 8 || day == 9) ||
                            month == 6 && (day == 5 || day == 6 || day == 21) ||
                            month == 7 ||
                            month == 11 && day == 1 ||
                            month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))) 
                                        => true,

                    _                   => false

                };
             };
    };

}