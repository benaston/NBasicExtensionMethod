using System;
using NUnit.Framework;
using FluentAssertions;
using NBasicExtensionMethod;

namespace NBasicExtensionMethod.Test.Fast
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        private DateTime mInvalidDateTimeLessThanMinDate = new DateTime(1899, 1, 1, 14, 30, 00);
        private DateTime mInvalidDateTimeGraterThanMaxDate = new DateTime(2101, 1, 1, 14, 30, 00);
        private DateTime mValidDateTime = new DateTime(2000, 1,1, 14,30, 00);
        
        [Test]
        public void IsValid_Should_Return_True_When_Date_Is_Grater_Than_MinDate_And_Less_Than_Max_Date()
        {
            // Arrange

            // Act & Assert
            mValidDateTime.IsValid().Should().BeTrue();
        }

        [Test]
        public void IsValid_Should_Return_False_When_Date_Is_Less_Than_MinDate_And_Less_Than_Max_Date()
        {
            // Arrange
            
            // Act & Assert
            mInvalidDateTimeLessThanMinDate.IsValid().Should().BeFalse();
        }

        [Test]
        public void IsValid_Should_Return_False_When_Date_Is_Grater_Than_MinDate_And_Grater_Than_Max_Date()
        {
            // Arrange
            
            // Act

            // Assert
            mInvalidDateTimeGraterThanMaxDate.IsValid().Should().BeFalse();
        }

        /*
         * 
         * The following IsInFuture tests are not written in the past way as they rely on the system date and time.
         * At the time of writting I haven't worked out a why around this.
         * 
         */

        [Test]
        public void IsInFuture_Should_Return_True_When_Date_Is_Grater_Than_Now()
        {
            // Arrange
            DateTime dtFutureDate = DateTime.Now.AddDays(2);
            // Act

            // Assert
            dtFutureDate.IsInFuture().Should().BeTrue();
        }

        [Test]
        public void IsInFuture_Should_Return_False_When_Date_Is_Less_Than_Now()
        {
            // Arrange
            DateTime dtValue = DateTime.Now.AddDays(-1);
            // Act

            // Assert
            dtValue.IsInFuture().Should().BeFalse();
        }
    }
}