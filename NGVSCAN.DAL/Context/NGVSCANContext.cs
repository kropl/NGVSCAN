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
        /// Линии (нитки, точки ...) измерения
        /// </summary>
        public IDbSet<MeasureLine> MeasureLines { get; set; }

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

            // Добавление конфигурации вычислителей ROC809
            modelBuilder.Configurations.Add(new ROC809Configuration());
        }
    }
}
