using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CRC.Test.Units
{
    public class CRC8Units
    {
        private Random random = new Random();
        private List<byte> TestingData => Enumerable
            .Range(0, random.Next(0, 1000))
            .Select(i => (byte)random.Next())
            .ToList();

        [Fact]
        public void TestAddWithBadArgs()
        {
            var crc = new CRC8();

            Assert.Throws<ArgumentNullException>(() => crc.Add(null));
        }

        [Fact]
        public void TestAppendWithBadArgs()
        {
            var crc = new CRC8();

            Assert.Throws<ArgumentNullException>(() => crc.Append(null));
        }

        [Fact]
        public void TestGetWithNull()
        {
            var crc = new CRC8();

            Assert.Throws<ArgumentNullException>(() => crc.Get(null));
            Assert.Throws<ArgumentNullException>(() => crc.Get(null, 0));
            Assert.Throws<ArgumentNullException>(() => crc.Get(null, 0, 0));
        }

        [Fact]
        public void TestVerifytWithNull()
        {
            var crc = new CRC8();

            Assert.Throws<ArgumentNullException>(() => crc.Verify(null));
            Assert.Throws<ArgumentNullException>(() => crc.Verify(null, 0));
            Assert.Throws<ArgumentNullException>(() => crc.Verify(null, 0, 0));
        }

        [Fact]
        public void TestGetStartWithBadArgs()
        {
            var crc = new CRC8();
            var data = Array.Empty<byte>();
            var size = 10;
            Array.Resize(ref data, size);

            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Get(data, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Get(data, size));
        }

        [Fact]
        public void TestVerifyStartWithBadArgs()
        {
            var crc = new CRC8();
            var data = Array.Empty<byte>();
            var size = 10;
            Array.Resize(ref data, size);

            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Verify(data, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Verify(data, size));
        }

        [Fact]
        public void TestGetCountWithBadArgs()
        {
            var crc = new CRC8();
            var data = Array.Empty<byte>();
            var size = 10;
            Array.Resize(ref data, size);

            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Get(data, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Get(data, size, 0));

            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Get(data, 0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Get(data, 0, size));
        }

        [Fact]
        public void TestVerifyCountWithBadArgs()
        {
            var crc = new CRC8();
            var data = Array.Empty<byte>();
            var size = 10;
            Array.Resize(ref data, size);

            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Verify(data, -1, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Verify(data, size, 0));

            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Verify(data, 0, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => crc.Verify(data, 0, size));
        }

        [Fact]
        public void TestAdd()
        {
            var crc = new CRC8();
            var data = TestingData;
            var count = data.Count;

            Assert.True(crc.Add(data).Count() == count + 1);
        }

        [Fact]
        public void TestAppend()
        {
            var crc = new CRC8();
            var data = TestingData;
            var count = data.Count;

            crc.Append(data);

            Assert.True(data.Count == count + 1);
        }

        [Fact]
        public void TestGet()
        {
            var crc = new CRC8();
            var data = TestingData;

            var crcValue = crc.Get(data);

            Assert.True(crcValue == crc.Get(data));
            Assert.True(crcValue == crc.Get(data, 0));
            Assert.True(crcValue == crc.Get(data, 0, data.Count - 1));

            data = TestingData;

            Assert.False(crcValue == crc.Get(TestingData));
            Assert.False(crcValue == crc.Get(TestingData, 0));
            Assert.False(crcValue == crc.Get(TestingData, 0, data.Count - 1));
        }

        [Fact]
        public void TestVerify()
        {
            var crc = new CRC8();

            var data = crc.Add(TestingData).ToList();

            Assert.True(crc.Verify(data));
            Assert.True(crc.Verify(data, 0));
            Assert.True(crc.Verify(data, 0, data.Count - 1));

            data = TestingData;

            Assert.False(crc.Verify(data));
            Assert.False(crc.Verify(data, 0));
            Assert.False(crc.Verify(data, 0, data.Count - 1));
        }
    }
}
