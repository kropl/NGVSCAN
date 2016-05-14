namespace NGVSCAN.CORE.Entities
{
    public class ROC809 : Estimator
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public int ROCUnit { get; set; }

        public int ROCGroup { get; set; }

        public int HostUnit { get; set}

        public int HostGroup { get; set}
    }
}
