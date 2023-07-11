using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.RepositoryInterface;
using CProASP.MiniDateBase.EFCore;
using CProASP.Transport;

namespace CProASP.Repository
{
    public class DataBaseTransportRepository : ITransportRepository
    {
        public ApplicationContext DbContext { get;}

        public DataBaseTransportRepository(ApplicationContext context)
        {
            DbContext = context;
        }
        public void AddTransport(IBaseTranspoert transpot)
        {
           DbContext.Transport.Add((BaseTransport)transpot);
           DbContext.SaveChanges();
        }

        public IBaseTranspoert GetTranspoert(int id)
        {
            return DbContext.Transport.FirstOrDefault(x => x.Id == id);
        }
    }
}
