using CProASP.Transport.Cargo;

namespace CProASP.Interfaces.BaseInterfaces
{
    public interface IBaseTranspoert
    {
        string Type { get; set; }
        double Speed { get; set; }
        double Weight { get; set; }
        string Status { get; set; }
        public ICollection<CharacteristicCargo> Cargos { get; set; }
    }
}
