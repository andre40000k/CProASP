using CProASP.Interfaces.ServicesInterface;
using CProASP.Services.RegisterObjects;
using CProASP.Transport;

namespace CProASP.MiniDateBase
{
    public static class GetDateBase
    { 
        public static BaseTransport ReadFile(int id)
        {
            string path = "Transports.txt";

            using (var streamread = new StreamReader(path))
            {
                string? line = File.ReadLines(path).Skip(id - 1).Take(1).FirstOrDefault();

                if (line == null)
                    return null;

                var atributs = line.Split(',');

                return GetTransport(atributs);
            }
        }

        private static BaseTransport GetTransport(string[] properti)
        {
            var transport = new BaseTransport(int.Parse(properti[0]), properti[1],
                double.Parse(properti[2]), double.Parse(properti[3]), properti[4]);

            return transport;
        }
    }
}
