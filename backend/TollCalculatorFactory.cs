using System;

namespace TollFeeCalculator
{

    public static class TollCalculatorFactory
    {
        public static Func<DateTime, int> GetTollCalculatorByTimeSlot
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



    }
}
