using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.ROC809Connection;
using System;
using System.Collections.Generic;

namespace NGVSCAN.DAL.Extensions
{
    public static class ROC809Extensions
    {
        public static Dictionary<DateTime, double> GetMinuteData(this ROC809MeasurePoint point)
        { 
            if (point != null)
            {
                byte[] request = new byte[15];
                byte[] response;
                var data = new Dictionary<DateTime, double>();

                ROC809 roc = point.Estimator as ROC809;
                int histSegment = point.HistSegment;

                request[0] = (byte)roc.ROCUnit;
                request[1] = (byte)roc.ROCGroup;
                request[2] = (byte)roc.HostUnit;
                request[3] = (byte)roc.HostGroup;
                request[4] = 0x88;
                request[5] = 0x07;
                request[6] = (byte)histSegment;
                request[7] = 0x00;
                request[8] = 0x00;
                request[9] = 0x00;
                request[10] = 0x00;
                request[11] = 0x01;
                request[12] = 0x1e;

                byte[] crc = BitConverter.GetBytes(Crc16.Compute(request));

                request[13] = crc[1];
                request[14] = crc[0];

                try
                {
                    response = TCPIPClient.Connect(roc.Address, roc.Port, request, 1000);

                    for (int j = 0; j < (response[11] / 2); j++)
                    {
                        DateTime period = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        double value = 0;

                        for (int k = 0; k < 2; k++)
                        {
                            byte[] tempBuff = new byte[4];

                            tempBuff[3] = response[15 + (k * 4) + (j * 8)];
                            tempBuff[2] = response[14 + (k * 4) + (j * 8)];
                            tempBuff[1] = response[13 + (k * 4) + (j * 8)];
                            tempBuff[0] = response[12 + (k * 4) + (j * 8)];

                            if (k == 0)
                                period = period.AddSeconds(BitConverter.ToUInt32(tempBuff, 0));
                            else
                                value = BitConverter.ToSingle(tempBuff, 0);
                        }

                        data.Add(period, value);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
