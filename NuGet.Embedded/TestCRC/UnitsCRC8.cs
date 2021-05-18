using CRC;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestCRC8
{
    public class UnitsCRC8
    {
        private Random random = new Random();
        private List<byte> data => Enumerable
            .Range(0, random.Next(0, 1000))
            .Select(i => (byte)random.Next())
            .ToList();

        [Fact]
        public void TestGetBadParams()
        {
            var data = this.data;

            Assert.Throws<ArgumentNullException>(() => CRC8.Get(null));
            Assert.Throws<ArgumentNullException>(() => CRC8.Get(null, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => CRC8.Get(data, data.Count + 1));
        }

        [Fact]
        public void TestAddBadParams()
        {
            Assert.Throws<ArgumentNullException>(() => CRC8.Add(null));
        }

        [Fact]
        public void TestAppendBadParams()
        {
            Assert.Throws<ArgumentNullException>(() => CRC8.Append(null));
        }

        [Fact]
        public void TestVerifyBadParams()
        {
            var data = this.data;

            Assert.Throws<ArgumentNullException>(() => CRC8.Verify(null));
            Assert.Throws<ArgumentNullException>(() => CRC8.Verify(null, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => CRC8.Verify(data, data.Count + 1));
        }

        [Fact]
        public void TestGet()
        {
            var data = this.data;

            Assert.True(CRC8.Get(data) == CRC8.Get(data, data.Count));
            Assert.True(CRC8.Get(data.Take(2)) == CRC8.Get(data, data.Count - 2));
            Assert.False(CRC8.Get(data) == CRC8.Get(data.Reverse<byte>()));
            Assert.False(CRC8.Get(data.Take(2)) == CRC8.Get(data.Reverse<byte>(), data.Count - 2));
        }

        [Fact]
        public void TestAdd()
        {
            var data = this.data;
            var dataCrc = CRC8.Add(data);

            Assert.True(CRC8.Get(data) == CRC8.Get(dataCrc, dataCrc.Count() - sizeof(byte)));
        }

        [Fact]
        public void TestAppend()
        {
            var data = this.data;
            var crc = CRC8.Get(data);

            CRC8.Append(data);

            Assert.True(crc == CRC8.Get(data, data.Count - sizeof(byte)));
        }

        [Fact]
        public void TestVerify()
        {
            var data = this.data;
            var dataBad = new List<byte>(data);
            dataBad.Add(0);
            CRC8.Append(data);

            Assert.True(CRC8.Verify(data));
            Assert.True(CRC8.Verify(data, data.Count));
            Assert.False(CRC8.Verify(dataBad));
            Assert.False(CRC8.Verify(dataBad, dataBad.Count));
        }
    }
}
