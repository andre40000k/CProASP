using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.RepositoryInterface;
using CProASP.Interfaces.ServicesInterface;

namespace CProASP.Services.RegisterObjects
{
    public class TransportService : ITransportService
    {
        // ОСНОВНІЕ ИЗМИНЕНИЯ 
        //protected readonly List<IBaseTranspoert> transpoertList = new List<IBaseTranspoert>();


        private readonly ITransportRepository _transportRepository;

        public TransportService(ITransportRepository transportRepository)
        {
            _transportRepository = transportRepository;
        }

        public void AddTransport(IBaseTranspoert transpot)
        {
            _transportRepository.AddTransport(transpot);
            //transpoertList.Add(transpot);
        }

        public IBaseTranspoert? GetTranspoert(int id)
        {
            //int id_list = id - 1;

            //if(TransportCount() < id_list || id_list < 0)
            //    return null;

            //return transpoertList.Skip(id_list).DefaultIfEmpty().FirstOrDefault();
            return _transportRepository.GetTranspoert(id);
        }

        //public IBaseTranspoert? GetTranspoert()
        //{
        //    return (IBaseTranspoert?)transpoertList;
        //}

        //public int TransportCount()
        //{
        //    return transpoertList.Count();
        //}
    }
}
