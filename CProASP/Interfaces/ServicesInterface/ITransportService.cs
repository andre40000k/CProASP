using CProASP.Interfaces.BaseInterfaces;
using CProASP.Transport.Transport;
using CProASP.Transport.TransportRequest;

namespace CProASP.Interfaces.ServicesInterface
{
    public interface ITransportService
    {
        // ОСНОВНІЕ ИЗМИНЕНИЯ 
        void AddTransport(BaseTransport transpot);

        BaseTransport GetTranspoert(int id);

        bool UpdateTransport(int id, BaseTransportRequest baseTransportRequest);

        //IBaseTranspoert GetTranspoert();

        //int TransportCount();
    }
}
