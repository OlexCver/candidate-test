using System;
using System.Collections.Generic;
using TollFeeCalculator;

public interface ITollCalculator 
{
    public int GetTollFee(IVechicleType vehicle, List<DateTime> dates);
}
