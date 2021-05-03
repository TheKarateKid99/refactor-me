using ProcessDelivery.Common;
using System;
using Xunit;

namespace ProcessDelivery.Tests
{
    public class RiskValidatorTests
    {

        [Fact]
        public void ShouldReturn_Exception_MissingRequiredProperties()
        {
            var brokenClass = new BrokenClass();

            var dateReturned = DateTime.Now;

            Assert.Throws<Exception>(() => RiksValidatorV2.ReturnRiskValidator(brokenClass, dateReturned));
        }

    }
}
