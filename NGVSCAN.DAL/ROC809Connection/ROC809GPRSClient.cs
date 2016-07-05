using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NGVSCAN.DAL.ROC809Connection
{
    public class ROC809GPRSClient
    {
        private SerialPort _serialPort;

        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public Parity Parity { get; set; }

        public int DataBits { get; set; }

        public StopBits StopBits { get; set; }

        public Handshake Handshake { get; set; }

        public string PhoneNumber { get; set; }

        private static bool _isBusy = false;

        public ROC809GPRSClient(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake, string phoneNumber)
        {
            PortName = portName;
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
            Handshake = handshake;

            PhoneNumber = phoneNumber;

            _serialPort = new SerialPort();

            _serialPort.PortName = PortName;
            _serialPort.BaudRate = BaudRate;
            _serialPort.Parity = Parity;
            _serialPort.DataBits = DataBits;
            _serialPort.StopBits = StopBits;
            _serialPort.Handshake = Handshake;
        }

        public byte[] GetData(byte[] request)
        {
            byte[] response = new byte[1024];

            try
            {
                while (_isBusy)
                {
                    Thread.Sleep(1000);
                }

                _isBusy = true;

                if (!_serialPort.IsOpen)
                    _serialPort.Open();
                else
                {
                    _serialPort.Close();
                    _serialPort.Open();
                }

                _serialPort.Write("AT&F\r\n");
                Thread.Sleep(500);
                _serialPort.Write("ATD");
                Thread.Sleep(500);
                _serialPort.WriteLine("AT+CMGS=\"" + PhoneNumber + "\"\r");
                _serialPort.Write(request, 0, request.Length);
                Thread.Sleep(1000);
                _serialPort.Read(response, 0, response.Length);

                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                _serialPort.Close();

                _isBusy = false;

                return response;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
