using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC
{
    public static class CRC8
    {
        /// <summary>
        /// Получить CRC
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte Get(IEnumerable<byte> data)
        {
            throw new NotImplementedException($"{nameof(CRC8)}.{nameof(Get)}");
        }

        /// <summary>
        /// Получить CRC, до заданного индекса
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="indexOff">До указанного индекса</param>
        /// <returns>CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static byte Get(IEnumerable<byte> data, int indexOff)
        {
            throw new NotImplementedException($"{nameof(CRC8)}.{nameof(Get)}");
        }

        /// <summary>
        /// Добавить CRC
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Данный + CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        public static IEnumerable<byte> Add(IEnumerable<byte> data)
        {
            throw new NotImplementedException($"{nameof(CRC8)}.{nameof(Add)}");
        }

        /// <summary>
        /// Добавить CRC
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static void Append(ICollection<byte> data)
        {
            throw new NotImplementedException($"{nameof(CRC8)}.{nameof(Append)}");
        }

        /// <summary>
        /// Проверить данные на корректность CRC
        /// </summary>
        /// <param name="data">Данные + CRC</param>
        /// <returns>True - Если CRC корректно</returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool Verify(IEnumerable<byte> data)
        {
            throw new NotImplementedException($"{nameof(CRC8)}.{nameof(Verify)}");
        }

        /// <summary>
        /// Проверить данные на корректность CRC, до заданного индекса
        /// </summary>
        /// <param name="data">Данные + CRC</param>
        /// <param name="indexOff">До указанного индекса</param>
        /// <returns>True - Если CRC корректно</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static bool Verify(IEnumerable<byte> data, int indexOff)
        {
            throw new NotImplementedException($"{nameof(CRC8)}.{nameof(Verify)}");
        }
    }
}
