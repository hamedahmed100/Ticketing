using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing
{
    public class SharedInfo
    {
        public static string ServerIp = "https://localhost:44334/";

        public enum EnumTaskType
        {
            Service = 1,
            General = 2
        }
    }
}
