using System.IO.Ports;


SerialPort _serialPort;
     
_serialPort = new SerialPort("COM6", 9600);

        
try
{
    if (!_serialPort.IsOpen)
    {
        Thread.Sleep(50);
        _serialPort.Open();
        Console.WriteLine("Seriële poort geopend.");
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

while(true)
{ 
    try
    {
        Thread.Sleep(1000);
        string serialMessage = _serialPort.ReadExisting();
        Console.WriteLine($"Ontvangen: {serialMessage}");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fout bij lezen van {_serialPort.PortName}: {ex.Message}");
    }
}
     
_serialPort.Close();
_serialPort.Dispose();
    
