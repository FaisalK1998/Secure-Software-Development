using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureDevApp.Models
{
    public enum PriorityOfTicket
    {
        Low, Medium, High
    }

    public class TicketPriority
    {
        [Key]
        public int PriorityId { get; set; }
        public int TicketId { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public PriorityOfTicket? PriorityOfTicket { get; set; }

    }
}