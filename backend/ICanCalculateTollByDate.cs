using System;

namespace TollFeeCalculator
{
    public interface ICanCalculateTollByDate
    {
        public int TollCalculatorByDate(DateTime date);
    }
}