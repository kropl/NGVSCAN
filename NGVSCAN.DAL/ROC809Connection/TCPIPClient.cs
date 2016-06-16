using System;
using System.Net;
using System.Net.Sockets;

namespace NGVSCAN.DAL.ROC809Connection
{
    /// <summary>
    /// Реализация TCP/IP клиента
    /// </summary>
    public static class TCPIPClient
    {
        /// <summary>
        /// Метод, осуществляющий соединение, посылку запроса и получение ответа
        /// </summary>
        /// <param name="ip">IP-адрес</param>
        /// <param name="port">Порт</param>
        /// <param name="request">Запрос</param>
        /// <param name="timeout">Таймаут соединения в мс.</param>
        /// <param name="status">Состояние соединения</param>
        /// <returns></returns>
        public static byte[] Connect(string ip, int port, byte[] request, int timeout)
        {
            try
            {
                // Определение т. н. конечной точки, т. е. удаленного устройства на основе IP-адреса и локального порта
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                // Определение сокета
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    // Запуск соединения с устройством
                    IAsyncResult connectResult = socket.BeginConnect(endPoint, null, null);

                    // Определение результата соединения с учётом заданного таймаута
                    bool connectSuccess = connectResult.AsyncWaitHandle.WaitOne(timeout, true);

                    // Если соединение установлено
                    if (connectSuccess)
                    {
                        // Завершение процесса соединения
                        socket.EndConnect(connectResult);

                        // Отправка запроса
                        int bytesSent = socket.Send(request);

                        // Определение буфера для принимаемых данных
                        byte[] receiveBuffer = new byte[1024];

                        // Получение ответа в определённый буфер, результат - количество принятых байтов
                        int bytesReceived = socket.Receive(receiveBuffer);

                        // Изменение размера буфера принятых данных на основе количества принятых байтов
                        Array.Resize<byte>(ref receiveBuffer, bytesReceived);

                        // Возврат принятых данных
                        return receiveBuffer;
                    }
                    // Если соединение не установлено
                    else
                    {
                        // Определение соответствующего исключения
                        throw new SocketException(10060);
                    }
                }
                // Перехват исключения ArgumentNullException
                catch (ArgumentNullException ex1)
                {
                    throw ex1;
                }
                // Перехват исключения SocketException
                catch (SocketException ex2)
                {
                    throw ex2;
                }
                // Перехват общего исключения
                catch (Exception ex3)
                {
                    throw ex3;
                }
                // Завершающие действия
                finally
                {
                    // Если 
                    if (socket.Connected)
                    {
                        // Освобождение ресурсов и закрытие сокета
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                }
            }
            // Перехват общего исключения
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
