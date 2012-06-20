using NUnit.Framework;
using FluentAssertions;
using NBasicExtensionMethod;

namespace NBasicExtensionMethod.Test.Fast
{
    [TestFixture]
    public class BooleanExtensionTests
    {
        [Test]
        public void And_Should_Return_True_When_Both_Values_Are_True()
        {
            // Arrange
            bool bValueA = true;
            bool bValueB = true;

            // Act & Assert
            bValueA.And(bValueB).Should().Be(true);
        }

        [Test]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public void And_Should_Return_False_When_One_Value_Is_False(bool bValueA, bool bValueB)
        {
            // Arrange
          
            // Act & Assert
            bValueA.And(bValueB).Should().Be(false);
        }

        [Test]
        public void Or_Should_Return_False_When_Both_Values_Are_False()
        {
            // Arrange
            bool bValueA = false;
            bool bValueB = false;

            // Act & Assert
            bValueA.Or(bValueB).Should().Be(false);
        }

        [Test]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public void Or_Should_Return_True_When_One_Value_Is_True(bool bValueA, bool bValueB)
        {
            // Arrange

            // Act & Assert
            bValueA.Or(bValueB).Should().Be(true);
        }
    }
}