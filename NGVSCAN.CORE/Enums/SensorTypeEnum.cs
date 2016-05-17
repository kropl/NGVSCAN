using System.ComponentModel;

namespace NGVSCAN.CORE.Enums
{
    public enum SensorTypeEnum
    {
        [Description("Диафрагма")]
        Diaphragm,

        [Description("Счётчик")]
        Counter,

        [Description("Массовый расходомер")]
        Massmeter
    }
}
