using System;
using TollFeeCalculator;
using Xunit;

namespace FeesCalculatorTest
{
    public class ResolverIfTollFreeTest
    {
        [Fact]
        public void ResolverIfTollFreeWhenWeekEnds()
        {
            //Arrange
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();
            //Act
            var result = resolverIfTollFree.IsTollFreeDate(new DateTime(2021, 12, 25, 6, 05, 0));
            //Assert
            Assert.True(result);
        }


        [Fact]
        public void ResolverIfTollFreeWhenWorkingDays()
        {
            //Arrange
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();
            //Act
            var result = resolverIfTollFree.IsTollFreeDate(new DateTime(2021, 12, 24, 6, 05, 0));
            //Assert
            Assert.False(result);
        }


        [Fact]
        public void ResolverIfTollFreeWhenCarShoulPay()
        {
            //Arrange
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();
            //Act
            var result = resolverIfTollFree.IsTollFreeVehicle(new Car());
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ResolverIfTollFreeWhenCarShoulNotPay()
        {
            //Arrange
            ICanResolveIfTollFree resolverIfTollFree = new ResolverIfTollFree();
            //Act
            var result = resolverIfTollFree.IsTollFreeVehicle(new Emergency());
            //Assert
            Assert.True(result);
        }
    }
}
