using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing
{
    public interface ITicketData
    {
        public List<Ticket> GetTickets();
        public Ticket GetTicket(int id);
        public Ticket Create(Ticket ticket);
        public Ticket Edit(Ticket ticket);
        public void Delete(Ticket ticket);

        public event EventHandler<NotificationEventArgs> TicketCreated;

    }
}
