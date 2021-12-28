using System;
using System.Collections.Generic;

/// <summary>
/// Note: Project setup with Nullable: enabled 
/// </summary>
namespace TollFeeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanCalculateTollByDate calculatorByDate = new CalculatorByDate();
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();

            var calculator = new TollCalculator(
                calculatorByDate,
                resolverIfTollFree
                );

            var dates = new List<DateTime>()
            {
                new DateTime(2021, 12, 23, 6, 05, 0),
                new DateTime(2021, 12, 23, 6, 55, 0),
                new DateTime(2021, 12, 23, 10, 50, 0),
                new DateTime(2021, 12, 23, 15, 50, 0),
            };


            //With Fee
            var resultWithFee = calculator.GetTollFee(new Car(), dates);
            Console.WriteLine($"{nameof(resultWithFee)}: {resultWithFee}");

            var tooManyDates = new List<DateTime>()
            {
                new DateTime(2021, 12, 23, 6, 05, 0),
                new DateTime(2021, 12, 23, 6, 55, 0),
                new DateTime(2021, 12, 23, 10, 50, 0),
                new DateTime(2021, 12, 23, 15, 50, 0),
                new DateTime(2021, 12, 23, 17, 05, 0),
                new DateTime(2021, 12, 23, 18, 45, 0),

            };

            //With Max Fee
            var resultWithMaxFee = calculator.GetTollFee(new Car(), tooManyDates);
            Console.WriteLine($"{nameof(resultWithMaxFee)}: {resultWithMaxFee}");

            //Without Fee
            var resultEmergencyNoFee = calculator.GetTollFee(new Emergency(), dates);
            Console.WriteLine($"{nameof(resultEmergencyNoFee)}: {resultEmergencyNoFee}");

            //Without Fee
            var resultDiplomatNoFee = calculator.GetTollFee(new Diplomat(), dates);
            Console.WriteLine($"{nameof(resultDiplomatNoFee)}: {resultDiplomatNoFee}");


            Console.ReadLine();

        }
    }
}
