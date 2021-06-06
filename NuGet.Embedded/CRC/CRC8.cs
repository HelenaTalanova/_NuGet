using System;
using System.Collections.Generic;
using System.Linq;

namespace CRC
{
    public class CRC8 : ICrcAlgorithm<byte>
    {
        public IEnumerable<byte> Add(IEnumerable<byte> values)
        {
            ValidParams(values, false);

            byte crc = Calculate(values);

            return values.Append(crc);
        }

        public void Append(ICollection<byte> values)
        {
            ValidParams(values, false);

            byte crc = Calculate(values);

            values.Add(crc);
        }

        public byte Get(IEnumerable<byte> values)
        {
            ValidParams(values, false);

            return Calculate(values);
        }

        public byte Get(IEnumerable<byte> values, int indexStart)
        {
            ValidParams(values, false, indexStart);

            return Calculate(values, indexStart);
        }

        public byte Get(IEnumerable<byte> values, int indexStart, int count)
        {
            ValidParams(values, false, indexStart, count);

            return Calculate(values, indexStart, count);
        }

        public bool Verify(IEnumerable<byte> values)
        {
            ValidParams(values, true);

            return Verification(values, 0, values.Count() - 1);
        }

        public bool Verify(IEnumerable<byte> values, int indexStart)
        {
            ValidParams(values, true, indexStart);

            return Verification(values, indexStart, values.Count() - 1);
        }



        public bool Verify(IEnumerable<byte> values, int indexStart, int count)
        {
            ValidParams(values, true, indexStart, count);

            return Verification(values, indexStart, count);
        }

        private byte Calculate(IEnumerable<byte> values, int skip = 0, int count = int.MaxValue)
        {
            byte crc = 0x00;
            var enumerator = values.GetEnumerator();

            while ((skip-- > 0) && enumerator.MoveNext()) ;
            while (enumerator.MoveNext() && (count-- > 0))
            {
                crc += enumerator.Current;
            }

            return (byte)(0x0100 - crc);
        }

        public bool Verification(IEnumerable<byte> values, int skip, int count)
        {
            byte crcA = Calculate(values, skip, count);
            byte crcB = values.Last();

            return crcA == crcB;
        }

        private void ValidParams(IEnumerable<byte> values, bool isVerify = false, int indexStart = 0, int count = 0)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            var Count = values.Count() - (isVerify ? 1 : 0);
            if (indexStart < 0 ||
                count < 0 ||
                indexStart >= Count ||
                indexStart + count > Count)
                throw new ArgumentOutOfRangeException(nameof(indexStart) + nameof(count));
        }
    }
}
