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
    public static class FloutecHourlyDataScanner
    {
        public static List<FloutecHourlyData> ProcessForAll(UnitOfWork unitOfWork, int address, int line)
        {
            try
            {
                return unitOfWork.FloutecHourlyDataRepository.GetAll(address, line);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<FloutecHourlyData> Process(UnitOfWork unitOfWork, int address, int line, DateTime from, DateTime to)
        {
            try
            {
                return unitOfWork.FloutecHourlyDataRepository.Get(address, line, from, to);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
