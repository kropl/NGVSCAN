
namespace NGVSCAN.CORE.Entities
{
    /// <summary>
    /// Описание сущности "Вычислитель ROC809"
    /// </summary>
    public class ROC809 : Estimator
    {
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
    }
}
