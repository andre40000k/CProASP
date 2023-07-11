using CProASP.Interfaces.BaseInterfaces;

namespace CProASP.Interfaces.RepositoryInterface
{
    public interface ITransportRepository
    {
        void AddTransport(IBaseTranspoert transpot);

        IBaseTranspoert GetTranspoert(int Id);
    }
}
