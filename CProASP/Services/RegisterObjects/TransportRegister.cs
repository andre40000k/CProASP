using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.ServicesInterface;

namespace CProASP.Services.RegisterObjects
{
    public class TransportRegister : ITransportRegister
    {
        // ОСНОВНІЕ ИЗМИНЕНИЯ 
        protected readonly List<IBaseTranspoert> transpoertList = new List<IBaseTranspoert>();
        public void AddTransport(IBaseTranspoert transpot)
        {
            transpoertList.Add(transpot);
        }

        public IBaseTranspoert? GetTranspoert(int id)
        {
            int id_list = id - 1;

            if(TransportCount() < id_list || id_list < 0)
                return null;

            return transpoertList.Skip(id_list).DefaultIfEmpty().FirstOrDefault();
        }

        public IBaseTranspoert? GetTranspoert()
        {
            return (IBaseTranspoert?)transpoertList;
        }

        public int TransportCount()
        {
            return transpoertList.Count();
        }
    }
}
