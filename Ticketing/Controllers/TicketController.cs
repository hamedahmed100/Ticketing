using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing.Controllers
{

    [ApiController]

    public class TicketController : ControllerBase
    {
        private ITicketData _ticketData;
        public TicketController(ITicketData ticketData)
        {
            _ticketData = ticketData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetTickets()
        {
            return Ok(_ticketData.GetTickets());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTicket(int id)
        {
            var ticket = _ticketData.GetTicket(id);

            if (ticket != null)
            {
                return Ok(ticket);
            }

            return NotFound($"Tickets with Id: {id} was not found");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Create(Ticket ticket)
        {
            //Create Instance of the User to be Notfied after ticket Creation
            var Users = new Users();
            _ticketData.TicketCreated += Users.OnTicketCreatation;

            //Create the Ticket
            _ticketData.Create(ticket);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + ticket.Id, ticket);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            var ticket = _ticketData.GetTicket(id);

            if (ticket != null)
            {
                _ticketData.Delete(ticket);

                return Ok();
            }

            return NotFound($"Tickets with Id: {id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult Edit(int id, Ticket ticket)
        {
            var Existing_ticket = _ticketData.GetTicket(id);

            if (Existing_ticket != null)
            {
                ticket.Id = id;
                _ticketData.Edit(ticket);

                return Ok(ticket);
            }

            return NotFound($"Tickets with Id: {id} was not found");
        }
    }
}
