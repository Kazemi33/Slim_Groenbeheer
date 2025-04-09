using System.IO.Ports;
using System.Threading.Tasks;

namespace SerialReader
{
    public class SerialReaderData
    {
        private SerialPort _serialPort;
        public event Action<string> DataReceived; // Event voor inkomende data

        public SerialReaderData()
        {
            _serialPort = new SerialPort("COM6", 9600);
            _serialPort.DataReceived += SerialPort_DataReceived;
            _serialPort.DtrEnable = true; // Enable DTR (Data Terminal Ready)
            _serialPort.DataReceived += (s, e) =>
            {
                Console.WriteLine(">>> DataReceived event getriggerd <<<");
            };
            _serialPort.ReadTimeout = 50;

        }
        public void SerialPortConnect()
        {

            try
            {
                if (!_serialPort.IsOpen)
                {
                    Thread.Sleep(50);
                    _serialPort.Open();
                    Console.WriteLine("Seriële poort geopend.");
                    _serialPort.DataReceived += SerialPort_DataReceived;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Fout: Geen toegang tot {_serialPort.PortName} - {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fout bij openen van {_serialPort.PortName}: {e.Message}");
            }

        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("DataReceived event is getriggerd");

            try
            {
                string serialMessage = _serialPort.ReadLine().Trim();
                Console.WriteLine($"Ontvangen: {serialMessage}");

                // Trigger het event zodat andere onderdelen dit kunnen oppikken
                DataReceived?.Invoke(serialMessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij lezen van {_serialPort.PortName}: {ex.Message}");
            }
        }

        public void SerialPortExit()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
            }
        }
    }
}
