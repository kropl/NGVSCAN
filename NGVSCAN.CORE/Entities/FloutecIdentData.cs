using NGVSCAN.CORE.Entities.Common;
using System;

namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Данные идентификации вычислителя ФЛОУТЭК"
    /// </summary>
    public class FloutecIdentData : IEntity, IFloutecData
    {
        #region Конструктор и поля

        public FloutecIdentData()
        {
        }

        #endregion

        #region Общие свойства

        /// <summary>
        /// Идентификатор (первичный ключ) данных идентификации
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время создания (добавления) данных идентификации
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата и время изменения (модификации) данных идентификации
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Признак удаления данных идентификации
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Дата и время удаления данных идентификации
        /// </summary>
        public DateTime? DateDeleted { get; set; }

        /// <summary>
        /// Адрес вычислителя * 10 + номер нитки измерения
        /// </summary>
        public int N_FLONIT { get; set; }

        #endregion

        #region Свойства

        /// <summary>
        /// Контрактный час
        /// </summary>
        public TimeSpan KONTRH { get; set; }

        /// <summary>
        /// Молярная концентрация N2, %
        /// </summary>
        public double NO2 { get; set; }

        /// <summary>
        /// Тип отбора (0 - угловой, 1 - фланцевый)
        /// </summary>
        public int OTBOR { get; set; }

        /// <summary>
        /// Коэффициент Ае для расчёта КТР трубы
        /// </summary>
        public double ACP { get; set; }

        /// <summary>
        /// Коэффициент Ае для расчёта КТР СУ
        /// </summary>
        public double ACS { get; set; }

        /// <summary>
        /// Коэффициент шероховатости трубопровода
        /// </summary>
        public double SHER { get; set; }

        /// <summary>
        /// Верхний предел измерения давления, кг/см2
        /// </summary>
        public double VERXP { get; set; }

        /// <summary>
        /// Плотность газа, если не измеряется
        /// </summary>
        public double PLOTN { get; set; }

        /// <summary>
        /// Диаметр трубы
        /// </summary>
        public double DTRUB { get; set; }

        /// <summary>
        /// Отсечка
        /// </summary>
        public double OTSECH { get; set; }

        /// <summary>
        /// Коэффициент Ве для расчёта КТР трубы
        /// </summary>
        public double BCP { get; set; }

        /// <summary>
        /// Коэффициент Ве для расчёта КТР СУ
        /// </summary>
        public double BCS { get; set; }

        /// <summary>
        /// Верхний предел измерения перепада давления, кг/м2
        /// </summary>
        public double VERXDP { get; set; }

        /// <summary>
        /// Нижний предел измерения температуры
        /// </summary>
        public double NIZT { get; set; }

        /// <summary>
        /// Молярная концентрация СО2, %
        /// </summary>
        public double CO2 { get; set; }

        /// <summary>
        /// Диаметр СУ
        /// </summary>
        public double DSU { get; set; }

        /// <summary>
        /// Коэффициент Се для расчёта КТР трубы
        /// </summary>
        public double CCP { get; set; }

        /// <summary>
        /// Коэффициент Се для расчёта КТР СУ
        /// </summary>
        public double CCS { get; set; }

        /// <summary>
        /// Нижний предел измерения давления, кг/см2
        /// </summary>
        public double NIZP { get; set; }

        /// <summary>
        /// Верхний предел измерения температуры
        /// </summary>
        public double VERXT { get; set; }

        /// <summary>
        /// Тип субстанции (0 - газ, 1 - конденсат)
        /// </summary>
        public int KONDENS { get; set; }

        /// <summary>
        /// Количество импульсов на 1 м3 счётчика
        /// </summary>
        public double KALIBSCH { get; set; }

        /// <summary>
        /// Расход, при котором счётчик останавливается, м3/час
        /// </summary>
        public double MINRSCH { get; set; }

        /// <summary>
        /// Максимально допустимый расход через счётчик, м3/час
        /// </summary>
        public double MAXRSCH { get; set; }

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
