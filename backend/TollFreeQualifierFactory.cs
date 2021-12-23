
using System;
using System.Collections.Generic;

namespace TollFeeCalculator
{
    public static class TollFreeQualifierFactory 
    {
        public static List<VehiclesTypes> GetFreeTollList => new()
        {
            { VehiclesTypes.Motorbike },
            { VehiclesTypes.Tractor },
            { VehiclesTypes.Emergency },
            { VehiclesTypes.Diplomat },
            { VehiclesTypes.Foreign },
            { VehiclesTypes.Military },
        };

    };

}