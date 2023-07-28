using CProASP.Transport.Cargo;

namespace CProASP.Transport.TransportRequest
{
    public class BaseTransportRequest
    {
        public string Type { get; set; }
        public double Speed { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
    }
}
