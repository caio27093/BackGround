using System;
using System.Collections.Generic;
using System.Text;

namespace AppBackGround.Services
{
    public interface IForegroundService
    {
        void StartService();
        void StopService();
    }
}
