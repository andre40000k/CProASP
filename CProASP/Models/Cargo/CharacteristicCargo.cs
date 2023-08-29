using CProASP.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CProASP.Transport.Cargo
{
    public class CharacteristicCargo
    {
        [Key]
        public int Id { get; }
        public int BaseTransportId { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }
        public double Weight { get; set; }

        //public CargoType Type { get; set; } = 0;
        //public BaseTransport BaseTransport { get; set; }

    }
}
