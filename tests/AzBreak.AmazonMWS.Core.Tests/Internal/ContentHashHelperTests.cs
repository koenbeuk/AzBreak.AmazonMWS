using AzBreak.AmazonMWS.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Tests.Internal
{
    [TestClass]
    public class ContentHashHelperTests
    {
        [TestMethod]
        public async Task ComputeMD5Hash_SimpleText_ComputesHash()
        {
            var input = "test";
            var expected = "CY9rzUYh03PK3k6DJie09g==";

            var hash = await ContentHashHelper.ComputeMD5Hash(new MemoryStream(Encoding.UTF8.GetBytes(input)));

            Assert.AreEqual(expected, hash);
        }
    }
}
