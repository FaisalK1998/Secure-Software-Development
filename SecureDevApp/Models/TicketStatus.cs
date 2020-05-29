using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureDevApp.Models
{
    public enum StatusOfTicket
    {
        Open, Resolved, Closed
    }

    public class TicketStatus
    {
        [Key]
        public int StatusId { get; set; }
        public int TicketId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public StatusOfTicket? StatusOfTicket { get; set; }

    }
}