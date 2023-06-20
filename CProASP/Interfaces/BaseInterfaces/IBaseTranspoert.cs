namespace CProASP.Interfaces.BaseInterfaces
{
    public interface IBaseTranspoert
    {
        int Id { get; }
        string Type { get; set; }
        double Speed { get; set; }
        double Weight { get; set; }
        string Status { get; set; }
    }
}
