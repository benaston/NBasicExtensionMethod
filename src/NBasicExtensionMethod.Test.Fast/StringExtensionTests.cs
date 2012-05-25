namespace NBasicExtensionMethod.Test.Fast
{
    using NUnit.Framework;

    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void AppSetting_SuppliedWithAnonyMousObject_UsesItCorrectly()
        {
            var s = "foo".AppSetting(new { exceptionOnNull = true, });
        }
    }
}