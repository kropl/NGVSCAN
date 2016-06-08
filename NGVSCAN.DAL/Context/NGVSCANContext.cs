using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.EntityConfigurations;
using System.Data.Entity;

namespace NGVSCAN.DAL.Context
{
    /// <summary>
    /// Контекст сохранённых данных опроса вычислителей 
    /// </summary>
    public class NGVSCANContext : DbContext
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// NGVSCAN - название строки подключения, установленной в App.config
        /// </summary>
        public NGVSCANContext() : base("NGVSCAN") { }

        #region Наборы сущностей

        /// <summary>
        /// Установки
        /// </summary>
        public IDbSet<Field> Fields { get; set; }

        /// <summary>
        /// Вычислители
        /// </summary>
        public IDbSet<Estimator> Estimators { get; set; }

        /// <summary>
        /// Вычислители ФЛОУТЭК
        /// </summary>
        public IDbSet<Floutec> Floutecs { get; set; }

        /// <summary>
        /// Вычислители ROC809
        /// </summary>
        public IDbSet<ROC809> ROC809s { get; set; }

        /// <summary>
        /// Линии (нитки, точки ...) измерения
        /// </summary>
        public IDbSet<MeasureLine> MeasureLines { get; set; }

        /// <summary>
        /// Линии измерения вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecMeasureLine> FloutecMeasureLines { get; set; }

        /// <summary>
        /// Точки измерения вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809MeasurePoint> ROC809MeasurePoints { get; set; }

        /// <summary>
        /// Часовые данные вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecHourlyData> FloutecHourlyData { get; set; }

        /// <summary>
        /// Данные идентификации вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecIdentData> FloutecIdentData { get; set; }

        /// <summary>
        /// Мгновенные данные вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecInstantData> FloutecInstantData { get; set; }

        #endregion

        /// <summary>
        /// Конфигурирование базы данных при создании
        /// </summary>
        /// <param name="modelBuilder"><see cref="DbModelBuilder"/></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Добавление конфигурации установок
            modelBuilder.Configurations.Add(new FieldConfiguration());

            // Добавление конфигурации вычислителей
            modelBuilder.Configurations.Add(new EstimatorConfiguration());

            // Добавление конфигурации линий измерения
            modelBuilder.Configurations.Add(new MeasureLineConfiguration());

            // Добавление конфигурации вычислителей ФЛОУТЭК
            modelBuilder.Configurations.Add(new FloutecConfiguration());

            // Добавление конфигурации линий измерения вычислителей ФЛОУТЭК
            modelBuilder.Configurations.Add(new FloutecMeasureLineConfiguration());

            // Добавление конфигурации часовых данных вычислителей ФЛОУТЭК
            modelBuilder.Configurations.Add(new FloutecHourlyDataConfiguration());

            // Добавление конфигурации данных идентификации вычислителей ФЛОУТЭК
            modelBuilder.Configurations.Add(new FloutecIdentDataConfiguration());

            // Добавление конфигурации мгновенных данных вычислителей ФЛОУТЭК
            modelBuilder.Configurations.Add(new FloutecInstantDataConfiguration());

            // Добавление конфигурации вычислителей ROC809
            modelBuilder.Configurations.Add(new ROC809Configuration());

            // Добавление конфигурации точек измерения вычислителей ROC809
            modelBuilder.Configurations.Add(new ROC809MeasurePointConfiguration());
        }
    }
}
