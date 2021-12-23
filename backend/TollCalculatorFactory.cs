using System;

namespace TollFeeCalculator
{

    public static class TollCalculatorFactory
    {
        public static Func<DateTime, int> GetTollCalculatorByDate
            => (date) =>
            {
                return (date.Hour, date.Minute) switch
                {
                    var timeSlot when (timeSlot.Hour == 6 && timeSlot.Minute >= 0 && timeSlot.Minute <= 29)
                           => 9,
                    var timeSlot when (timeSlot.Hour == 6 && timeSlot.Minute >= 30 && timeSlot.Minute <= 59)
                           => 16,
                    var timeSlot when (timeSlot.Hour == 7 && timeSlot.Minute >= 0 && timeSlot.Minute <= 59)
                           => 22,
                    var timeSlot when (timeSlot.Hour == 8 && timeSlot.Minute >= 0 && timeSlot.Minute < 29)
                           => 16,
                    var timeSlot when (timeSlot.Hour >= 8 && timeSlot.Hour <= 14 && timeSlot.Minute >= 30 && timeSlot.Minute <= 59)
                           => 9,
                    var timeSlot when (timeSlot.Hour == 15 && timeSlot.Minute >= 0 && timeSlot.Minute <= 29)
                           => 16,
                    var timeSlot when (timeSlot.Hour == 15 && timeSlot.Minute >= 0 || timeSlot.Hour == 16 && timeSlot.Minute <= 59)
                           => 22,
                    var timeSlot when (timeSlot.Hour == 17 && timeSlot.Minute >= 0 && timeSlot.Minute <= 59)
                           => 16,
                    var timeSlot when (timeSlot.Hour == 18 && timeSlot.Minute >= 0 && timeSlot.Minute <= 29)
                           => 8,
                    _      => 0

                };
            };


        public static Func<DateTime, bool> GetFreeToolDatesQualifier
            => (date) =>
            {
                int year  = date.Year;
                int month = date.Month;
                int day   = date.Day;

                return date.DayOfWeek switch
                {
                    DayOfWeek.Saturday => true,
                    DayOfWeek.Sunday => true,

                    _ when (year == 2013) &&
                           (month == 1 && day == 1 ||
                            month == 3 && (day == 28 || day == 29) ||
                            month == 4 && (day == 1 || day == 30) ||
                            month == 5 && (day == 1 || day == 8 || day == 9) ||
                            month == 6 && (day == 5 || day == 6 || day == 21) ||
                            month == 7 ||
                            month == 11 && day == 1 ||
                            month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                        => true,

                    _   => false

                };
            };



    }
}
