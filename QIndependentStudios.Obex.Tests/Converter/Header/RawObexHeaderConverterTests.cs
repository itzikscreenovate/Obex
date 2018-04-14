using Microsoft.VisualStudio.TestTools.UnitTesting;
using QIndependentStudios.Obex.Converter.Header;
using QIndependentStudios.Obex.Header;
using System.Linq;

namespace QIndependentStudios.Obex.Tests.Converter.Header
{
    [TestClass]
    public class RawObexHeaderConverterTests
    {
        private static readonly byte[] TestHeaderData =
        {
            0x42, 0x00, 0x18, 0x78, 0x2D, 0x62, 0x74, 0x2F,
            0x4D, 0x41, 0x50, 0x2D, 0x6D, 0x73, 0x67, 0x2D,
            0x6C, 0x69, 0x73, 0x74, 0x69, 0x6E, 0x67, 0x00
        };
        private static readonly ObexHeader TestHeader = RawObexHeader.Create(ObexHeaderId.Type,
            TestHeaderData.Skip(3).ToArray());

        private readonly RawObexHeaderConverter _converter = RawObexHeaderConverter.Instance;

        [TestMethod]
        public void FromBytes_GivenHeaderByteData_ReturnsHeaderObject()
        {
            var actual = _converter.FromBytes(TestHeaderData);

            Assert.AreEqual(TestHeader, actual);
        }

        [TestMethod]
        public void ToBytes_GivenHeaderObject_ReturnsHeaderByteData()
        {
            var actual = _converter.ToBytes(TestHeader);

            Assert.IsTrue(TestHeaderData.SequenceEqual(actual));
        }
    }
}
