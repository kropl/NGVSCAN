namespace NGVSCAN.CORE.Entities.Common
{
    /// <summary>
    /// Интерфейс общего поведения справочных таблиц
    /// </summary>
    public interface ICatalog
    {
        /// <summary>
        /// Код
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
    }
}
