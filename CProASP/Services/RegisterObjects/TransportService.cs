using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.RepositoryInterface;
using CProASP.Interfaces.ServicesInterface;
using CProASP.Transport.Transport;
using CProASP.Transport.TransportRequest;
using System.Reflection.Metadata.Ecma335;

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

        public void AddTransport(BaseTransport transpot)
        {
            _transportRepository.AddTransport(transpot);
            //transpoertList.Add(transpot);
        }

        public BaseTransport? GetTranspoert(int id)
        {
            //int id_list = id - 1;

            //if(TransportCount() < id_list || id_list < 0)
            //    return null;

            //return transpoertList.Skip(id_list).DefaultIfEmpty().FirstOrDefault();
            return _transportRepository.GetTranspoert(id);
        }

        public bool UpdateTransport(int id, BaseTransportRequest TransporRequest)
        {
            var curentTransport = GetTranspoert(id);

            if (curentTransport == null) { return false; }

            var propertiesReqest = TransporRequest.GetType().GetProperties();
            var propertiesCurrent = curentTransport.GetType().GetProperties();

            foreach (var propertyReqest in propertiesReqest)
            {
                string propNameRequest = propertyReqest.Name;

                foreach (var propertyCurrent in propertiesCurrent)
                {
                    string propNameCurrent = propertyCurrent.Name;

                    if (propNameCurrent == "Id" ||
                        propNameCurrent == "Cargos")
                        continue;

                    if (propNameCurrent == propNameRequest)
                    {
                        var requestPropValue = propertyReqest.GetValue(TransporRequest);
                        var currentPropValue = propertyCurrent.GetValue(curentTransport);

                        if (currentPropValue != requestPropValue)
                            propertyCurrent.SetValue(curentTransport, requestPropValue);

                        continue;
                    }
                    
                }

            }

            _transportRepository.UpDate(curentTransport);

            return true;
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
