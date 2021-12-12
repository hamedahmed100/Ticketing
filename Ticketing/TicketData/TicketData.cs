using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Models;

namespace Ticketing
{
    public class TicketData : ITicketData
    {
        private TicketContext dbContext;

        //Creating an Event Handler to watch if a ticket is Created
        public event EventHandler<NotificationEventArgs> TicketCreated;
        //Return the Created Ticket to Notify all the Concerned  Classes
        protected virtual void OnTicketCreatation(Ticket ticket)
        {
            if (TicketCreated != null)
                TicketCreated(this, new NotificationEventArgs() { Ticket = ticket });

        }

        public TicketData(TicketContext _context)
        {
            this.dbContext = _context;
        }
        public Ticket Create(Ticket ticket)
        {
            dbContext.Tickets.Add(ticket);
            dbContext.SaveChanges();

            //Sending Notification after Creating a ticket
            OnTicketCreatation(ticket);

            return ticket;
        }

        public void Delete(Ticket ticket)
        {

            dbContext.Tickets.Remove(ticket);
            dbContext.SaveChanges();
        }

        public Ticket Edit(Ticket ticket)
        {
            var getTicket = dbContext.Tickets.FirstOrDefault(t => t.Id == ticket.Id);

            getTicket.Subject = ticket.Subject;
            getTicket.Details = ticket.Details;
            getTicket.TicketType = ticket.TicketType;

            dbContext.SaveChanges();

            return ticket;
        }

        public Ticket GetTicket(int id)
        {
            return this.dbContext.Tickets.SingleOrDefault(t => t.Id == id);

        }

        public List<Ticket> GetTickets()
        {
            return this.dbContext.Tickets.ToList();
        }
    }
}
