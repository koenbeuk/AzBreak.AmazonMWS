using AzBreak.AmazonMWS.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Tests.Internal
{
    [TestClass]
    public class DateTimeHelperTests
    {
        [TestMethod]
        public void ToIsoDateTimeString_WithUtcDateTime_FormatsCorrectly()
        {
            var input = new DateTime(2009, 03, 03, 19, 12, 22, DateTimeKind.Utc);
            var expected = "2009-03-03T19:12:22Z";

            var actual = DateTimeHelper.ToIsoDateTimeString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDateTime_WithLocalDateTimeOffset_ParsesExpectedValue()
        {
            var input = "2009-03-03T18:12:22Z";
            var expected = new DateTimeOffset(2009, 03, 03, 19, 12, 22, TimeSpan.FromHours(1));

            var actual = DateTimeHelper.ToDateTimeOffset(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToDateTime_WithExtraPrecision_ParsesExpectedValue()
        {
            var input = "2017-11-16T11:27:41.667Z";
            var expected = new DateTime(2017, 11, 16, 11, 27, 41, 667, DateTimeKind.Utc);

            var actual = DateTimeHelper.ToDateTimeOffset(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
