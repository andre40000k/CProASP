﻿using CProASP.Interfaces.ServicesInterface;

namespace CProASP.Services.RegisterObjects.ChangObjects
{
    public class TransportChang : TransportRegister, ITransportChang
    {
        public int CountList()
        {
            return transpoertList.Count();
        }

        public void RemoveTransport(int id)
        {
            transpoertList.RemoveAt(id);
        }
    }
}
