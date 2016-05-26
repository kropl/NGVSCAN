using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Часовые данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecHourlyData : IEntity, IFloutecData
    {
        #region Конструктор и поля

        public FloutecHourlyData()
        {
        }

        #endregion

        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) часовых данных
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) часовых данных
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) часовых данных
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления часовых данных
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления часовых данных
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        public int N_FLONIT { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Дата и время начала периода накопления
        /// </summary>
        public DateTime DAT { get; set; }

        /// <summary>
        /// Дата и время окончания периода накопления
        /// </summary>
        public DateTime DAT_END { get; set; }

        /// <summary>
        /// Количество, м3 или т
        /// </summary>
        public double RASX { get; set; }

        /// <summary>
        /// Среднее давление
        /// </summary>
        public double DAVL { get; set; }

        /// <summary>
        /// Признак константы среднего давления (* - константа, ' - ЗПЗ)
        /// </summary>
        public string PD { get; set; }

        /// <summary>
        /// Средняя температура
        /// </summary>
        public double TEMP { get; set; }

        /// <summary>
        /// Признак константы средней температуры (* - константа, ' - ЗПЗ)
        /// </summary>
        public string PT { get; set; }

        /// <summary>
        /// Средний перепад давления
        /// </summary>
        public double PEREP { get; set; }

        /// <summary>
        /// Признак константы среднего перепада давления (* - константа, ' - ЗПЗ)
        /// </summary>
        public string PP { get; set; }

        /// <summary>
        /// Средняя плотность
        /// </summary>
        public double PLOTN { get; set; }

        /// <summary>
        /// Признак константы средней плотности (* - константа, ' - ЗПЗ)
        /// </summary>
        public string PL { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Идентификатор (первичный ключ) линии измерения 
        /// </summary>
        public int FloutecMeasureLineId { get; set; }

        /// <summary>
        /// Линия измерения
        /// </summary>
        public virtual FloutecMeasureLine MeasureLine { get; set; }

        #endregion
    }
}
