using System;
using System.Collections.Generic;

namespace CRC
{
    interface ICrcAlgorithm<ValueType> where ValueType:struct
    {
        /// <summary>
        /// Получить CRC для всех елементов
        /// </summary>
        /// <param name="values">Набор елементов</param>
        /// <returns>CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        ValueType Get(IEnumerable<ValueType> values);

        /// <summary>
        /// Получить CRC для елементов начиная с заданного индекса
        /// </summary>
        /// <param name="values">Набор елементов</param>
        /// <param name="indexStart">Индекс начала</param>
        /// <returns>CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        ValueType Get(IEnumerable<ValueType> values, int indexStart);

        /// <summary>
        /// Получить CRC для елементов начиная с заданного индекса, для указанного количества
        /// </summary>
        /// <param name="values">Набор елементов</param>
        /// <param name="indexStart">Индекс начала</param>
        /// <param name="count">Количество от индекса начала элементов</param>
        /// <returns>CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        /// /// <exception cref="ArgumentOutOfRangeException"/>
        ValueType Get(IEnumerable<ValueType> values, int indexStart, int count);

        /// <summary>
        /// Добавить CRC к набору елементов
        /// </summary>
        /// <param name="values">Набор елементов</param>
        /// <returns>Набор елементов + CRC</returns>
        /// <exception cref="ArgumentNullException"/>
        IEnumerable<ValueType> Add(IEnumerable<ValueType> values);

        /// <summary>
        /// Присоеденить CRC к набору елементов
        /// </summary>
        /// <param name="values">Набор елементов</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        void Append(ICollection<ValueType> values);

        /// <summary>
        /// Проверить (набор елементов + CRC) на соотвествие CRC
        /// </summary>
        /// <param name="values">Набор елементов + CRC</param>
        /// <returns>True - Если CRC корректно</returns>
        /// <exception cref="ArgumentNullException"/>
        bool Verify(IEnumerable<ValueType> values);

        /// <summary>
        /// Проверить (набор елементов + CRC) на соотвествие CRC для елементов начиная с заданного индекса
        /// </summary>
        /// <param name="values">Набор елементов + CRC</param>
        /// <param name="indexStart">Индекс начала</param>
        /// <returns>True - Если CRC корректно</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        bool Verify(IEnumerable<ValueType> values, int indexStart);

        /// <summary>
        /// Проверить (набор елементов + CRC) на соотвествие CRC для елементов начиная с заданного индекса, для указанного количества (не включая CRC)
        /// </summary>
        /// <param name="values">Набор елементов + CRC</param>
        /// <param name="indexStart">Индекс начала</param>
        /// <param name="count">Количество от индекса начала элементов, не включая CRC</param>
        /// <returns>True - Если CRC корректно</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        bool Verify(IEnumerable<ValueType> values, int indexStart, int count);
    }
}
