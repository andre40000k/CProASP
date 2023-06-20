using CProASP.Interfaces.BaseInterfaces;

namespace CProASP.Interfaces.ServicesInterface
{
    public interface ITransportRegister
    {
        void AddTransport(IBaseTranspoert transpot);

        IBaseTranspoert GetTranspoert(int id);

        IBaseTranspoert GetTranspoert();

        int TransportCount();
    }
}
