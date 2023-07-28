using CProASP.Interfaces.BaseInterfaces;
using CProASP.Transport.Cargo;
using System.ComponentModel.DataAnnotations;

namespace CProASP.Transport.Transport
{
    public class BaseTransport : IBaseTranspoert
    {
        [Key]
        public int Id { get; }
        public string Type { get; set; }
        public double Speed { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
        public ICollection<CharacteristicCargo> Cargos { get; set; }

        //public BaseTransport(int id, string type, double speed, double weight, string status)
        //{
        //    Id = id;
        //    Type = type;
        //    Speed = speed;
        //    Weight = weight;
        //    Status = status;
        //}
    }
}
