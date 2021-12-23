using System;

namespace TollFeeCalculator
{
    public class CalculatorByDate : ICanCalculateTollByDate
    {

        public int TollCalculatorByDate(DateTime date)
            => TollCalculatorFactory.GetTollCalculatorByDate(date);

    }
}