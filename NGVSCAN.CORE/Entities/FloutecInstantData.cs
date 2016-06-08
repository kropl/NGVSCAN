using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Мгновенные данные вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecInstantData : IEntity, IFloutecData
    {
        #region Конструктор и поля

        public FloutecInstantData()
        {
        }

        #endregion

        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) мгновенных данных
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) мгновенных данных
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) мгновенных данных
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления мгновенных данных
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления мгновенных данных
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        public int N_FLONIT { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Дата и время момента опроса данных
        /// </summary>
        public DateTime DAT { get; set; }

        /// <summary>
        /// Объём с начала часа
        /// </summary>
        public double QHOUR { get; set; }

        /// <summary>
        /// Объём за предыдущий час
        /// </summary>
        public double PQHOUR { get; set; }

        /// <summary>
        /// Текущий расход
        /// </summary>
        public double CURRSPEND { get; set; }

        /// <summary>
        /// Объём с начала контрактных суток
        /// </summary>
        public double DAYSPEND { get; set; }

        /// <summary>
        /// Объём за прошлые сутки
        /// </summary>
        public double YESTSPEND { get; set; }

        /// <summary>
        /// Объём с начала месяца
        /// </summary>
        public double MONTHSPEND { get; set; }

        /// <summary>
        /// Объём за прошлый месяц
        /// </summary>
        public double LASTMONTHSPEND { get; set; }

        /// <summary>
        /// Общий объём
        /// </summary>
        public double ALLSPEND { get; set; }

        /// <summary>
        /// Объём при с.у. за текущие сутки, накопленный при аварийных ситуациях
        /// </summary>
        public double ALARMSY { get; set; }

        /// <summary>
        /// Объём при р.у. за текущие сутки, накопленный при аварийных ситуациях
        /// </summary>
        public double ALARMRY { get; set; }

        /// <summary>
        /// Объём при с.у. за предыдущие сутки, накопленный при аварийных ситуациях
        /// </summary>
        public double PALARMSY { get; set; }

        /// <summary>
        /// Объём при р.у. за предыдущие сутки, накопленный при аварийных ситуациях
        /// </summary>
        public double PALARMRY { get; set; }

        /// <summary>
        /// Перепад давления (для счётчика - приращение объёма при р.у.)
        /// </summary>
        public double PERPRES { get; set; }

        /// <summary>
        /// Признак константы для перепада давления (* - константа)
        /// </summary>
        public string PP { get; set; }

        /// <summary>
        /// Статическое давление
        /// </summary>
        public double STPRES { get; set; }

        /// <summary>
        /// Признак константы для статического давления (* - константа)
        /// </summary>
        public string PD { get; set; }

        /// <summary>
        /// Абсолютное давление
        /// </summary>
        public double ABSP { get; set; }

        /// <summary>
        /// Температура
        /// </summary>
        public double TEMP { get; set; }

        /// <summary>
        /// Признак константы для температуры (* - константа)
        /// </summary>
        public string PT { get; set; }

        /// <summary>
        /// Вязкость газа
        /// </summary>
        public double GASVIZ { get; set; }

        /// <summary>
        /// Корень квадратный (значение плотности, если измеряется)
        /// </summary>
        public double SQROOT { get; set; }

        /// <summary>
        /// Плотность газа при р.у.
        /// </summary>
        public double GAZPLOTNRU { get; set; }

        /// <summary>
        /// Плотность газа при н.у.
        /// </summary>
        public double GAZPLOTNNU { get; set; }

        /// <summary>
        /// Суммарная длительность аварийных ситуаций за текущие сутки, сек.
        /// </summary>
        public int DLITAS { get; set; }

        /// <summary>
        /// Длительность измерительных аварийных ситуаций за текущие сутки, сек.
        /// </summary>
        public int DLITBAS { get; set; }

        /// <summary>
        /// Длительность методических аварийных ситуаций за текущие сутки, сек.
        /// </summary>
        public int DLITMAS { get; set; }

        /// <summary>
        /// Суммарная длительность аварийных ситуаций за предыдущие сутки, сек.
        /// </summary>
        public int PDLITAS { get; set; }

        /// <summary>
        /// Длительность измерительных аварийных ситуаций за предыдущие сутки, сек.
        /// </summary>
        public int PDLITBAS { get; set; }

        /// <summary>
        /// Длительность методических аварийных ситуаций за предыдущие сутки, сек.
        /// </summary>
        public int PDLITMAS { get; set; }

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
