using System;
using TollFeeCalculator;

public interface ITollCalculator 
{
    public int GetTollFee(IVehicle vehicle, DateTime[] dates);
}
