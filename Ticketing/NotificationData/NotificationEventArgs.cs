using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing
{
    public class NotificationEventArgs :EventArgs
    {
        public Ticket Ticket { get; set; }
    }
}
