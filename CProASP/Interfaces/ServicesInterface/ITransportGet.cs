using CProASP.Interfaces.BaseInterfaces;

namespace CProASP.Interfaces.ServicesInterface
{
    public interface ITransportGet
    {
        IBaseTranspoert GetTranspoert(int id);

        IBaseTranspoert GetTranspoert();
    }
}
