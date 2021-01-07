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
    public class QueryHelpersTests
    {
        [TestMethod]
        public void BuildCanonicalQueryString_NoParameters_ReturnsEmptyString()
        {
            var parameters = new Dictionary<string, object>();
            var result = QueryHelper.BuildCanonicalQueryString(parameters);

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void BuildCanonicalQueryString_ParametersWithoutValues_IncludesAndRetainsEqualsSymbol()
        {
            var parameters = new Dictionary<string, object>
            {
                { "foo", null },
                { "bar", "" },
                { "baz", 1 }
            };
            var result = QueryHelper.BuildCanonicalQueryString(parameters);

            Assert.AreEqual("foo=&bar=&baz=1", result);
        }
    }
}
