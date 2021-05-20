using System;
using System.Collections.Generic;
using System.Linq;

namespace CRC
{
    public class CRC8 : ICrcAlgorithm<byte>
    {
        public IEnumerable<byte> Add(IEnumerable<byte> values)
        {
            var crc = values.Select(i=>(int)i).Sum();
            return values.Append((byte)crc);
            //throw new NotImplementedException();
        }

        public void Append(ICollection<byte> values)
        {
            var crc = values.Select(i => (int)i).Sum();
            values.Add((byte)crc);
            //throw new NotImplementedException();
        }

        public byte Get(IEnumerable<byte> values)
        {
            var crc = values.Select(i => (int)i).Sum();
            return (byte)crc;
            //throw new NotImplementedException();
        }

        public byte Get(IEnumerable<byte> values, int indexStart)
        {
            throw new NotImplementedException();
        }

        public byte Get(IEnumerable<byte> values, int indexStart, int count)
        {
            throw new NotImplementedException();
        }

        public bool Verify(IEnumerable<byte> values)
        {
            var crc = values.Take(values.Count() - 1).Select(i => (int)i).Sum();
            return crc == values.Last();
            //throw new NotImplementedException();
        }

        public bool Verify(IEnumerable<byte> values, int indexStart)
        {
            throw new NotImplementedException();
        }

        public bool Verify(IEnumerable<byte> values, int indexStart, int count)
        {
            throw new NotImplementedException();
        }
    }
}
