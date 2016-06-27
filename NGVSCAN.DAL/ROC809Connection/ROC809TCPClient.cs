using System;
using System.Net.Sockets;

namespace NGVSCAN.DAL.ROC809Connection
{
    /// <summary>
    /// Клиент для соединения с вычислителем ROC809
    /// </summary>
    public class ROC809TCPClient
    {
        #region Конструктор и поля

        private TcpClient _client;
        private NetworkStream stream;

        private string _ip;
        private int _port;

        /// <summary>
        /// Клиент для соединения с вычислителем ROC809
        /// </summary>
        /// <param name="ip">Ip-адрес</param>
        /// <param name="port">Порт</param>
        public ROC809TCPClient(string ip, int port)
        {
            // Инициализация полей
            _ip = ip;
            _port = port;
            _client = new TcpClient();
        }

        #endregion

        /// <summary>
        /// Получение данных из вычислителя ROC809
        /// </summary>
        /// <param name="request">Массив байтов запроса</param>
        /// <returns>Массив байтов ответа</returns>
        public byte[] GetData(byte[] request)
        {
            try
            {
                // Если соединение не было установлено, то установить
                if (!_client.Connected)
                    _client.Connect(_ip, _port);

                // Получение потока
                stream = _client.GetStream();

                // Запись запроса в поток
                stream.Write(request, 0, request.Length);
                stream.Flush();

                // Чтение ответа из потока
                byte[] response = new byte[1024];
                int receivedBytes = stream.Read(response, 0, response.Length);

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
