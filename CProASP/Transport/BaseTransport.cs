using CProASP.Interfaces.BaseInterfaces;

namespace CProASP.Transport
{
    public class BaseTransport : IBaseTranspoert
    {
        public int Id { get;}
        public string Type { get; set; }
        public double Speed { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }

        public BaseTransport(int id, string type, double speed, double weight, string status)
        {
            Id = id;
            Type = type;
            Speed = speed;
            Weight = weight;
            Status = status;
        }
    }
}
