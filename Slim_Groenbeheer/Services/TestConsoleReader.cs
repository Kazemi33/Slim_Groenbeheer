        using System;
using System.IO.Ports;
//using System.IO.Ports;

namespace Slim_Groenbeheer.Services
{
    public class TestConsoleReader
    {


class Program
    {
        static void Main(string[] args)
        {
            SerialPort port = new SerialPort("COM6", 9600);
            port.ReadTimeout = 1000;

            try
            {
                port.Open();
                Console.WriteLine("Seriële poort geopend.");

                while (true)
                {
                    try
                    {
                        string line = port.ReadLine();
                        Console.WriteLine($"Ontvangen: {line}");
                    }
                    catch (TimeoutException)
                    {
                        // Geen data deze ronde
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout: {ex.Message}");
            }
            finally
            {
                if (port.IsOpen)
                    port.Close();
            }
        }
    }

}
}
