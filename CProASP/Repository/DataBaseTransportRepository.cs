using CProASP.Interfaces.BaseInterfaces;
using CProASP.Interfaces.RepositoryInterface;
using CProASP.MiniDateBase.EFCore;
using CProASP.Transport.Transport;
using Microsoft.EntityFrameworkCore;

namespace CProASP.Repository
{
    public class DataBaseTransportRepository : ITransportRepository
    {
        private readonly ApplicationContext _context /*DbContext{ get;}*/;

        public DataBaseTransportRepository(ApplicationContext context)
        {
            _context = context;
            
        }
        public void AddTransport(BaseTransport transpot)
        {
            
            _context.Transport.Add(transpot);
            _context.SaveChanges();
        }

        public BaseTransport? GetTranspoert(int id)
        {
            return _context.Transport
                .Include(x => x.Cargos)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<BaseTransport> GetTranspoert(BaseTransport baseTransport)
        {
            return _context.Transport.ToList();
        }

        public void UpDate(BaseTransport baseTransport)
        {
            _context.Transport.Update(baseTransport);
            _context.SaveChanges();
        }
    }
}
