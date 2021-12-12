using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing
{
    public class Users
    {
        public void OnTicketCreatation(object source, NotificationEventArgs e)
        {
            //Here we got the Retured Ticket after it's creation 
            //So We Can Write the Implementation logic for the Notification here using FireBase or SignalR
            //e.Ticket 
            var createdTicket = e.Ticket;
        }
    }
}
