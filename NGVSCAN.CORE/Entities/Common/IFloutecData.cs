namespace NGVSCAN.CORE.Entities.Common
{
    /// <summary>
    /// Интерфейс общего содержания сущностей записей данных для вычислителя ФЛОУТЭК
    /// </summary>
    public interface IFloutecData
    {
        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        int N_FLONIT { get; }
    }
}
