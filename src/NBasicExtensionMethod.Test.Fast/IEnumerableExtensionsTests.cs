using System.Collections.Generic;
using NUnit.Framework;
using NBasicExtensionMethod;
using FluentAssertions;

namespace NBasicExtensionMethod.Test.Fast
{
    [TestFixture]
    public class IEnumerableExtensionsTests
    {
        [Test]
        public void IsNotNullOrEmpty_Should_Return_True_When_Passed_A_Non_Empty_List()
        {
            // Arrange
            List<string> Products = new List<string> {"DummyValue"};
            // Act

            // Assert
            Products.IsNotNullOrEmpty().Should().BeTrue();
        }
        
        [Test]
        public void IsNotNullOrEmpty_Should_Return_False_When_Passed_An_Empty_List()
        {
            // Arrange
            List<string> Products = new List<string>();
            // Act

            // Assert
            Products.IsNotNullOrEmpty().Should().BeFalse();
        }

        [Test]
        public void IsNotNullOrEmpty_Should_Return_False_When_Passed_A_Null_List()
        {
            // Arrange
            List<string> Products = null;
            // Act

            // Assert
            Products.IsNotNullOrEmpty().Should().BeFalse();
        }
    }
}