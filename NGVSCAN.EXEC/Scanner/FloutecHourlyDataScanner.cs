using NGVSCAN.CORE.Entities;
using NGVSCAN.DAL.UnitOfWork;
using NGVSCAN.EXEC.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGVSCAN.EXEC.Scanner
{
    public class FloutecHourlyDataScanner
    {
        private readonly UnitOfWork _unitOfWork;
        private int _address;
        private int _line;
        private DateTime _from;
        private DateTime _to;
        private ListView _logger;

        private List<FloutecHourlyData> _hourlyData;

        public FloutecHourlyDataScanner(ListView logger, UnitOfWork unitOfWork, int address, int line, DateTime from, DateTime to)
        {
            _unitOfWork = unitOfWork;
            _address = address;
            _line = line;
            _from = from;
            _to = to;
            _logger = logger;
        }

        public void ProcessForAll()
        {
            BackgroundWorker bwGetAll = new BackgroundWorker();
            bwGetAll.WorkerSupportsCancellation = true;
            bwGetAll.WorkerReportsProgress = true;

            bwGetAll.DoWork += bwGetAll_DoWork;
            bwGetAll.RunWorkerCompleted += bwGetAll_RunWorkerCompleted;

            bwGetAll.RunWorkerAsync();
        }

        private void bwGetAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Logger.Log(_logger, e.Error.Message, LogType.Error);
            }
            else
            {
                Logger.Log(_logger, "Опрос нитки №" + _line + " вычислителя ФЛОУТЭК с адресом " + _address + " выполнен успешно", LogType.Success);
            }
        }

        private void bwGetAll_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _hourlyData = _unitOfWork.FloutecHourlyDataRepository.GetAll(_address, _line);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
