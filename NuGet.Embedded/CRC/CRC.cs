namespace CRC
{
    public class CRC
    {
        public static void Add<ValueType>(ICrcAlgorithm<ValueType> instance) where ValueType : struct
        {
            CrcTool<ValueType>.Set(instance);
        }

        public static ICrcAlgorithm<ValueType> Get<ValueType>() where ValueType : struct
        {
            return CrcTool<ValueType>.Instance;
        }
    }
}
