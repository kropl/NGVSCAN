using System;

namespace NGVSCAN.CORE.Entities.ROC809s.Common
{
    /// <summary>
    /// Интерфейс общего содержания сущностей записей периодических данных для вычислителя ROC809
    /// </summary>
    public interface IROC809PeriodicData
    {
        /// <summary>
        /// Период накопления (усреднения) данных
        /// </summary>
        DateTime DatePeriod { get; set; }

        /// <summary>
        /// Накопленное (усреднённое) значение
        /// </summary>
        double Value { get; set; } 
    }
}
