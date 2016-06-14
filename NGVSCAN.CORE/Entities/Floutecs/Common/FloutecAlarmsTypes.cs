namespace NGVSCAN.CORE.Entities.Floutecs.Common
{
    /// <summary>
    /// Описание сущности "Типы аварий вычислителей ФЛОУТЭК"
    /// </summary>
    public class FloutecAlarmsTypes
    {
        /// <summary>
        /// Код аварии
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Описание кода аварии для вычислителей с версией ПО до 45
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Описание кода аварии для вычислителей с версией ПО от 45 включительно
        /// </summary>
        public string Description_45 { get; set; }
    }
}
