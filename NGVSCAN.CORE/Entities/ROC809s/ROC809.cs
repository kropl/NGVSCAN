using System.Collections.Generic;

namespace NGVSCAN.CORE.Entities.ROC809s
{
    /// <summary>
    /// Описание сущности "Вычислитель ROC809"
    /// </summary>
    public class ROC809 : Estimator
    {
        #region Конструктор и поля

        public ROC809()
        {
            // Инициализация коллекции данных событий
            EventData = new HashSet<ROC809EventData>();

            // Инициализация коллекции данных аварий
            AlarmData = new HashSet<ROC809AlarmData>();
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Адрес вычислителя ROC809
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Порт вычислителя ROC809
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// ROCUnit вычислителя ROC809
        /// </summary>
        public int ROCUnit { get; set; }

        /// <summary>
        /// ROCGroup вычислителя ROC809
        /// </summary>
        public int ROCGroup { get; set; }

        /// <summary>
        /// HostUnit вычислителя ROC809
        /// </summary>
        public int HostUnit { get; set; }

        /// <summary>
        /// HostGroup вычислителя ROC809
        /// </summary>
        public int HostGroup { get; set; }

        #endregion

        #region Навигационные свойства

        /// <summary>
        /// Коллекция данных событий 
        /// </summary>
        public virtual ICollection<ROC809EventData> EventData { get; set; }

        /// <summary>
        /// Коллекция данных аварий 
        /// </summary>
        public virtual ICollection<ROC809AlarmData> AlarmData { get; set; }

        #endregion
    }
}
