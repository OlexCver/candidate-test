using System;
using System.Collections.Generic;
using TollFeeCalculator;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanCalculateTollByDate calculatorByDate = new CalculatorByDate();
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();

            var dates = new List<DateTime>()
            {
                new DateTime(2021, 12, 23, 6, 30, 0),
                new DateTime(2021, 12, 23, 7, 45, 0),
                new DateTime(2021, 12, 23, 10, 50, 0),
                new DateTime(2021, 12, 23, 15, 50, 0),
            };


            var calculator = new TollCalculator(
                calculatorByDate,
                resolverIfTollFree
                );

            var result = calculator.GetTollFee(new Car(), dates);
            Console.WriteLine($"result: {result}");

            var result2 = calculator.GetTollFee(new Emergency(), dates);
            Console.WriteLine($"result: {result2}");

            Console.ReadLine();

        }
    }
}
