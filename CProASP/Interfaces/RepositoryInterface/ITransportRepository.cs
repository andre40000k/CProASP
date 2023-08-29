using CProASP.Interfaces.BaseInterfaces;
using CProASP.Transport.Transport;

namespace CProASP.Interfaces.RepositoryInterface
{
    public interface ITransportRepository
    {
        void AddTransport(BaseTransport transpot);

        BaseTransport GetTranspoert(int Id);

        void UpDate(BaseTransport baseTransport);
    }
}
