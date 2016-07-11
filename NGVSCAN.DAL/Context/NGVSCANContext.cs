using NGVSCAN.CORE.Entities;
using NGVSCAN.CORE.Entities.Floutecs;
using NGVSCAN.CORE.Entities.Floutecs.Common;
using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.EntityConfigurations;
using NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations;
using NGVSCAN.DAL.EntityConfigurations.FloutecsConfigurations.Common;
using NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations;
using System.Data.Common;
using System.Data.Entity;
using NGVSCAN.DAL.EntityConfigurations.ROC809sConfigurations.Common;
using NGVSCAN.CORE.Entities.ROC809s.Common;
using NGVSCAN.DAL.Migrations;

namespace NGVSCAN.DAL.Context
{
    /// <summary>
    /// Контекст сохранённых данных опроса вычислителей 
    /// </summary>
    public class NGVSCANContext : DbContext
    {
        /// <summary>
        /// Контекст сохранённых данных опроса вычислителей
        /// Строка подключения установлена в App.config
        /// </summary>
        public NGVSCANContext() : base("NGVSCAN")
        {
            // Инициализация базы данных при создании
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NGVSCANContext, Configuration>("NGVSCAN"));
        }

        /// <summary>
        /// Контекст сохранённых данных опроса вычислителей
        /// </summary>
        /// <param name="connection">Соединение с базой данных</param>
        public NGVSCANContext(DbConnection connection) : base(connection, true)
        {
            // Инициализация базы данных при создании
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NGVSCANContext, Configuration>(true));
        }

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

        /// <summary>
        /// Данные аварий вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecAlarmData> FloutecAlarmData { get; set; }

        /// <summary>
        /// Данные вмешательств вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecInterData> FloutecInterData { get; set; }

        /// <summary>
        /// Коды параметров вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecParamsTypes> FloutecParamsTypes { get; set; }

        /// <summary>
        /// Коды аварий вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecAlarmsTypes> FloutecAlarmsTypes { get; set; }

        /// <summary>
        /// Коды вмешательств вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecIntersTypes> FloutecIntersTypes { get; set; }

        /// <summary>
        /// Типы датчиков вычислителей ФЛОУТЭК
        /// </summary>
        public IDbSet<FloutecSensorsTypes> FloutecSensorsTypes { get; set; }

        /// <summary>
        /// Минутные данные вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809MinuteData> ROC809MinuteData { get; set; }

        /// <summary>
        /// Периодические данные вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809PeriodicData> ROC809PeriodicData { get; set; }

        /// <summary>
        /// Суточные данные вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809DailyData> ROC809DailyData { get; set; }

        /// <summary>
        /// Данные событий вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809EventData> ROC809EventData { get; set; }

        /// <summary>
        /// Типы событий вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809EventsTypes> ROC809EventsTypes { get; set; }

        /// <summary>
        /// Дополнительные коды типов событий вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809EventsCodes> ROC809EventsCodes { get; set; }

        /// <summary>
        /// Типы аварий вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809AlarmsTypes> ROC809AlarmsTypes { get; set; }

        /// <summary>
        /// Дополнительные коды типов аварий вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809AlarmsCodes> ROC809AlarmsCodes { get; set; }

        /// <summary>
        /// Данные аварий вычислителей ROC809
        /// </summary>
        public IDbSet<ROC809AlarmData> ROC809AlarmData { get; set; }

        #endregion

        // Конфигурирование базы данных при создании
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Добавление конфигураций

            modelBuilder.Configurations.Add(new FieldConfiguration());
            modelBuilder.Configurations.Add(new EstimatorConfiguration());
            modelBuilder.Configurations.Add(new MeasureLineConfiguration());
            modelBuilder.Configurations.Add(new FloutecConfiguration());
            modelBuilder.Configurations.Add(new FloutecMeasureLineConfiguration());
            modelBuilder.Configurations.Add(new FloutecHourlyDataConfiguration());
            modelBuilder.Configurations.Add(new FloutecIdentDataConfiguration());
            modelBuilder.Configurations.Add(new FloutecInstantDataConfiguration());
            modelBuilder.Configurations.Add(new FloutecAlarmDataConfiguration());
            modelBuilder.Configurations.Add(new FloutecInterDataConfiguration());
            modelBuilder.Configurations.Add(new ROC809Configuration());
            modelBuilder.Configurations.Add(new ROC809MeasurePointConfiguration());
            modelBuilder.Configurations.Add(new FloutecParamsTypesConfiguration());
            modelBuilder.Configurations.Add(new FloutecAlarmsTypesConfiguration());
            modelBuilder.Configurations.Add(new FloutecIntersTypesConfiguration());
            modelBuilder.Configurations.Add(new FloutecSensorsTypesConfiguration());
            modelBuilder.Configurations.Add(new ROC809DailyDataConfiguration());
            modelBuilder.Configurations.Add(new ROC809MinuteDataConfiguration());
            modelBuilder.Configurations.Add(new ROC809PeriodicDataConfiguration());
            modelBuilder.Configurations.Add(new ROC809EventsTypesConfiguration());
            modelBuilder.Configurations.Add(new ROC809EventsCodesConfiguration());
            modelBuilder.Configurations.Add(new ROC809EventDataConfiguration());
            modelBuilder.Configurations.Add(new ROC809AlarmsTypesConfiguration());
            modelBuilder.Configurations.Add(new ROC809AlarmsCodesConfiguration());
            modelBuilder.Configurations.Add(new ROC809AlarmDataConfiguration());
        }
    }
}
