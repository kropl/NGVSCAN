using NGVSCAN.CORE.Entities.ROC809s;
using NGVSCAN.DAL.ROC809Connection;
using System;
using System.Collections.Generic;

namespace NGVSCAN.DAL.Extensions
{
    /// <summary>
    /// Статический класс с расширениями для вычислителей ROC809
    /// </summary>
    public static class ROC809Extensions
    {
        /// <summary>
        /// Получение периодических данных вычислителя ROC809
        /// </summary>
        /// <param name="point">Точка измерения</param>
        /// <param name="historyType">Тип периодических данных<see cref="ROC809HistoryType"/></param>
        /// <returns>Периодические данные</returns>
        public static Dictionary<DateTime, double> GetPeriodicData(this ROC809MeasurePoint point, ROC809HistoryType historyType)
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
            request[9] = (byte)historyType;
            request[10] = 0x00;
            request[11] = 0x01;
            request[12] = 0x1e;

            byte[] crc = BitConverter.GetBytes(Crc16.Compute(request));

            request[13] = crc[1];
            request[14] = crc[0];

            try
            {
                do
                {
                    response = TCPIPClient.Connect(roc.Address, roc.Port, request, 1000);

                    for (int j = 0; j < (response[11] / 2); j++)
                    {
                        DateTime period = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        double value = 0;

                        for (int k = 0; k < 2; k++)
                        {
                            if (k == 0)
                                period = period.AddSeconds(BitConverter.ToUInt32(response.SubArray(12 + (k * 4) + (j * 8), 4), 0));
                            else
                                value = BitConverter.ToSingle(response.SubArray(12 + (k * 4) + (j * 8), 4), 0);
                        }

                        data.Add(period, value);
                    }

                    request[7] = response[9];
                    request[8] = response[10];

                } while (response[11] % request[12] == 0);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return data;
        }

        /// <summary>
        /// Получение данных событий вычислителя ROC809
        /// </summary>
        /// <param name="point">Точка измерения</param>
        /// <returns>Данные событий</returns>
        public static List<ROC809EventData> GetEventData(this ROC809MeasurePoint point)
        {
            byte[] request = new byte[11];
            byte[] response;
            var data = new List<ROC809EventData>();

            ROC809 roc = point.Estimator as ROC809;

            request[0] = (byte)roc.ROCUnit;
            request[1] = (byte)roc.ROCGroup;
            request[2] = (byte)roc.HostUnit;
            request[3] = (byte)roc.HostGroup;
            request[4] = 0x77;
            request[5] = 0x03;
            request[6] = 0x0a;
            request[7] = 0x00;
            request[8] = 0x00;

            byte[] crc = BitConverter.GetBytes(Crc16.Compute(request));

            request[9] = crc[1];
            request[10] = crc[0];

            try
            {
                do
                {
                    response = TCPIPClient.Connect(roc.Address, roc.Port, request, 1000);

                    for (int i = 0; i < response[6]; i++)
                    {
                        var record = new ROC809EventData();
                        DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);

                        record.Type = response[11];

                        record.Time = time.AddSeconds(BitConverter.ToUInt32(response.SubArray(12, 4), 0));
                        
                        switch(record.Type)
                        {
                            case 0:
                                break;
                            case 1:
                                {
                                    record.OperatorId = BitConverter.ToInt32(response.SubArray(16, 3), 0);

                                    record.T = response[19];
                                    record.L = response[20];
                                    record.P = response[21];

                                    switch (response[22])
                                    {
                                        case 0:
                                            {
                                                record.NewValue = BitConverter.ToBoolean(response.SubArray(23, 1), 0) ? "1" : "0";
                                                record.OldValue = BitConverter.ToBoolean(response.SubArray(27, 1), 0) ? "1" : "0";
                                                break;
                                            }
                                        case 1:
                                            {
                                                record.NewValue = response[23].ToString();
                                                record.OldValue = response[27].ToString();
                                                break;
                                            }
                                        case 2:
                                            {
                                                record.NewValue = BitConverter.ToInt16(response.SubArray(23, 2), 0).ToString();
                                                record.OldValue = BitConverter.ToInt16(response.SubArray(27, 2), 0).ToString();
                                                break;
                                            }
                                        case 3:
                                            {
                                                record.NewValue = BitConverter.ToInt32(response.SubArray(23, 4), 0).ToString();
                                                record.OldValue = BitConverter.ToInt32(response.SubArray(27, 4), 0).ToString();
                                                break;
                                            }
                                        case 4:
                                            {
                                                record.NewValue = response[23].ToString();
                                                record.OldValue = response[27].ToString();
                                                break;
                                            }
                                        case 5:
                                            {
                                                record.NewValue = BitConverter.ToInt16(response.SubArray(23, 2), 0).ToString();
                                                record.OldValue = BitConverter.ToInt16(response.SubArray(27, 2), 0).ToString();
                                                break;
                                            }
                                        case 6:
                                            {
                                                record.NewValue = BitConverter.ToUInt32(response.SubArray(23, 4), 0).ToString();
                                                record.OldValue = BitConverter.ToUInt32(response.SubArray(27, 4), 0).ToString();
                                                break;
                                            }
                                        case 7:
                                            {
                                                record.NewValue = BitConverter.ToSingle(response.SubArray(23, 4), 0).ToString();
                                                record.OldValue = BitConverter.ToSingle(response.SubArray(27, 4), 0).ToString();
                                                break;
                                            }
                                        case 8:
                                            {
                                                record.NewValue = response[23] + ", " + response[24] + ", " + response[25];
                                                record.OldValue = response[27] + ", " + response[28] + ", " + response[29];
                                                break;
                                            }
                                        case 9:
                                            {
                                                record.NewValue = BitConverter.ToSingle(response.SubArray(23, 3), 0).ToString();
                                                record.OldValue = BitConverter.ToSingle(response.SubArray(27, 3), 0).ToString();
                                                break;
                                            }
                                        case 10:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 7), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 11:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 10), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 12:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 10), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 13:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 10), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 14:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 10), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 15:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 10), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 16:
                                            {
                                                record.NewValue = BitConverter.ToDouble(response.SubArray(23, 8), 0).ToString();
                                                record.OldValue = "";
                                                break;
                                            }
                                        case 17:
                                            {
                                                record.NewValue = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(BitConverter.ToUInt32(response.SubArray(23, 4), 0)).ToString("dd.MM.yyyy HH:mm:ss");
                                                record.OldValue = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(BitConverter.ToUInt32(response.SubArray(27, 4), 0)).ToString("dd.MM.yyyy HH:mm:ss");
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case 2:
                                {                  
                                    record.Code = response[16];
                                    record.Description = BitConverter.ToString(response.SubArray(17, 16), 0);

                                    break;
                                }
                            case 3:
                                {
                                    record.FST = response[16];
                                    record.Value = BitConverter.ToSingle(response.SubArray(17, 4), 0).ToString();

                                    break;
                                }
                            case 4:
                                {
                                    record.OperatorId = BitConverter.ToInt32(response.SubArray(16, 3), 0);
                                    record.Code = response[19];
                                    record.Description = BitConverter.ToString(response.SubArray(20, 13), 0);

                                    break;
                                }
                            case 5:
                                {
                                    record.Value = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(BitConverter.ToUInt32(response.SubArray(16, 4), 0)).ToString("dd.MM.yyyy HH:mm:ss");

                                    break;
                                }
                            case 6:
                                {
                                    record.Value = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(BitConverter.ToUInt32(response.SubArray(16, 4), 0)).ToString("dd.MM.yyyy HH:mm:ss");

                                    break;
                                }
                            case 7:
                                {
                                    record.OperatorId = BitConverter.ToInt32(response.SubArray(16, 3), 0);
                                    record.T = response[19];
                                    record.L = response[20];
                                    record.P = response[21];
                                    record.RawValue = BitConverter.ToSingle(response.SubArray(22, 4), 0).ToString();
                                    record.CalibratedValue = BitConverter.ToSingle(response.SubArray(26, 4), 0).ToString();
                                    break;
                                }
                        }

                        data.Add(record);
                    }

                    request[7] = response[9];
                    request[8] = response[10];

                } while (response[6] % request[6] == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        /// <summary>
        /// Получение данных аварий вычислителя ROC809
        /// </summary>
        /// <param name="point">Точка измерения</param>
        /// <returns>Данные аварий</returns>
        public static List<ROC809AlarmData> GetAlarmData(this ROC809MeasurePoint point)
        {
            byte[] request = new byte[11];
            byte[] response;
            var data = new List<ROC809AlarmData>();

            ROC809 roc = point.Estimator as ROC809;

            request[0] = (byte)roc.ROCUnit;
            request[1] = (byte)roc.ROCGroup;
            request[2] = (byte)roc.HostUnit;
            request[3] = (byte)roc.HostGroup;
            request[4] = 0x76;
            request[5] = 0x03;
            request[6] = 0x0a;
            request[7] = 0x00;
            request[8] = 0x00;

            byte[] crc = BitConverter.GetBytes(Crc16.Compute(request));

            request[9] = crc[1];
            request[10] = crc[0];

            try
            {
                do
                {
                    response = TCPIPClient.Connect(roc.Address, roc.Port, request, 1000);

                    for (int i = 0; i < response[6]; i++)
                    {
                        var record = new ROC809AlarmData();
                        DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);

                        record.SRBX = (response[11] & (1 << 7)) != 0;
                        record.Condition = (response[11] & (1 << 6)) != 0;
                        record.Type = response[11] & 63;

                        record.Time = time.AddSeconds(BitConverter.ToUInt32(response.SubArray(12, 4), 0));

                        switch (record.Type)
                        {
                            case 0:
                                break;
                            case 1:
                                {
                                    record.Code = response[16];
                                    record.T = response[17];
                                    record.L = response[18];
                                    record.P = response[19];
                                    record.Description = BitConverter.ToString(response.SubArray(20, 10), 0);
                                    record.Value = BitConverter.ToSingle(response.SubArray(30, 4), 0).ToString();

                                    break;
                                }
                            case 2:
                                {
                                    record.FST = response[16];
                                    record.Description = BitConverter.ToString(response.SubArray(17, 13), 0);
                                    record.Value = BitConverter.ToSingle(response.SubArray(30, 4), 0).ToString();

                                    break;
                                }
                            case 3:
                                {
                                    record.Description = BitConverter.ToString(response.SubArray(16, 18), 0);

                                    break;
                                }
                            case 4:
                                {
                                    record.Description = BitConverter.ToString(response.SubArray(16, 14), 0);
                                    record.Value = BitConverter.ToSingle(response.SubArray(30, 4), 0).ToString();

                                    break;
                                }
                        }

                        data.Add(record);
                    }

                    request[7] = response[9];
                    request[8] = response[10];

                } while (response[6] % request[6] == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        // Получение элементов массива, начиная с заданной позиции
        private static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
