using System;

namespace CRC
{
    internal class CrcTool<ValueType> where ValueType : struct
    {
        private static ICrcAlgorithm<ValueType> instance;
        public static ICrcAlgorithm<ValueType> Instance => instance ?? GetDefaultImplementation<ValueType>();

        public static void Set(ICrcAlgorithm<ValueType> _instance)
        {
            instance = _instance;
        }

        protected static ICrcAlgorithm<ValueType> GetDefaultImplementation<InitValueType>() where InitValueType : struct
        {
            if (typeof(InitValueType) == typeof(byte))
                instance = new CRC8() as ICrcAlgorithm<ValueType>;

            return instance ??
                throw new NotImplementedException(
                    $"Not found implementation default for <{nameof(ICrcAlgorithm<ValueType>)}<{typeof(ValueType)}>>.\n" +
                    $"Set your own implementation {nameof(ICrcAlgorithm<ValueType>)}<{typeof(ValueType)}> for the type <{typeof(ValueType)}>," +
                    $" use method {nameof(CRC)}.{nameof(CRC.Add)}()"
                    );
        }
    }
}
