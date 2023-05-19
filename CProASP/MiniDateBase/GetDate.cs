using CProASP.Transport;

namespace CProASP.MiniDateBase
{
    public static class GetDateBase
    {
        public static List<BaseTransport> ReadFile()
        {
            string path = "Transports.txt";             
            
            var transports = new List<BaseTransport>(); 

            using(var streamread = new StreamReader(path))
            {
                string? line;

                while((line = streamread.ReadLine())  != null)
                {
                    var atributs = line.Split(',');
                    
                    transports.Add(GetTransport(atributs));
                }
            }

            return transports;
        }

        private static BaseTransport GetTransport(string[] properti)
        {
           var transport = new BaseTransport()
           {
               Id = int.Parse(properti[0]),
               Type = properti[1],
               Speed = double.Parse(properti[2]),
               Weight = double.Parse(properti[3]),
               Status= properti[4]
           };
            
            return transport;
        }
    }
}
