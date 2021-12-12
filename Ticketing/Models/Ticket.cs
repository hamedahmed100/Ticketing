using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Ticketing
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Subject can only be 100 characters")]
        public string Subject { get; set; }
        public string Details { get; set; }
        public SharedEnum.EnumTaskType TicketType { get; set; }

    }
}

