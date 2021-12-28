using System;
using System.Collections.Generic;
using TollFeeCalculator;
using Xunit;

namespace FeesCalculatorTest
{
    public class TollCalculatorTest 
    {
        [Fact]
        public void TollCalculatorWhenNeedToPay()
        {
            //Arrange
            ICanCalculateTollByDate calculatorByDate = new CalculatorByDate();
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();

            ITollCalculator calculator = new TollCalculator(
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

            //Act
            var result = calculator.GetTollFee(new Car(), dates);
            //Assert
            Assert.Equal(47, result);
        }


        [Fact]
        public void TollCalculatorWhenNeedToPayMax()
        {
            //Arrange
            ICanCalculateTollByDate calculatorByDate = new CalculatorByDate();
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();

            ITollCalculator calculator = new TollCalculator(
                calculatorByDate,
                resolverIfTollFree
                );

            var tooManyDates = new List<DateTime>()
            {
                new DateTime(2021, 12, 23, 6, 05, 0),
                new DateTime(2021, 12, 23, 6, 55, 0),
                new DateTime(2021, 12, 23, 10, 50, 0),
                new DateTime(2021, 12, 23, 15, 50, 0),
                new DateTime(2021, 12, 23, 17, 05, 0),
                new DateTime(2021, 12, 23, 18, 45, 0),

            };
            //Act
            var result = calculator.GetTollFee(new Car(), tooManyDates);
            //Assert
            Assert.Equal(60, result);
        }

        [Fact]
        public void TollCalculatorWhenNoNeedToPayForSpecialCar()
        {
            //Arrange
            ICanCalculateTollByDate calculatorByDate = new CalculatorByDate();
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();

            ITollCalculator calculator = new TollCalculator(
                calculatorByDate,
                resolverIfTollFree
                );

            var tooManyDates = new List<DateTime>()
            {
                new DateTime(2021, 12, 23, 6, 05, 0),
                new DateTime(2021, 12, 23, 6, 55, 0),
                new DateTime(2021, 12, 23, 10, 50, 0),
                new DateTime(2021, 12, 23, 15, 50, 0),
                new DateTime(2021, 12, 23, 17, 05, 0),
                new DateTime(2021, 12, 23, 18, 45, 0),

            };
            //Act
            var result = calculator.GetTollFee(new Emergency(), tooManyDates);
            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void TollCalculatorWhenNoNeedToPayForSpecialDays()
        {
            //Arrange
            ICanCalculateTollByDate calculatorByDate = new CalculatorByDate();
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();

            ITollCalculator calculator = new TollCalculator(
                calculatorByDate,
                resolverIfTollFree
                );

            var tooManyDates = new List<DateTime>()
            {
                new DateTime(2021, 12, 25, 6, 05, 0),
                new DateTime(2021, 12, 25, 6, 55, 0),
                new DateTime(2021, 12, 25, 10, 50, 0),
                new DateTime(2021, 12, 25, 15, 50, 0),
                new DateTime(2021, 12, 25, 17, 05, 0),
                new DateTime(2021, 12, 25, 18, 45, 0),

            };
            //Act
            var result = calculator.GetTollFee(new Car(), tooManyDates);
            //Assert
            Assert.Equal(0, result);
        }
    }
}
