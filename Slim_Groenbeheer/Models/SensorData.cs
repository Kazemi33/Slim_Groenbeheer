namespace Slim_Groenbeheer.Models
{
    public class SensorData
    {

        public int id { get; set; }
        public string naam { get; set; }
        public int kas_id { get; set; }


    }

    public class KassenData
    {

        public int id { get; set; }
        public int kas_nummer { get; set; }
        public string locatie { get; set; }


    }

    public class MetingenData
    {

        public int sensor_id { get; set; }
        public double waarde { get; set; }
        public DateTime moment { get; set; }


    }
    public class SerialMessageData
    {
        public string message { get; set; }
    }
}
