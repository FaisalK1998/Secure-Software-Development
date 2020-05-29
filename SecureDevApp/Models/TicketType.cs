using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureDevApp.Models
{
    public enum TypeOfTicket
    {
        Development, Production, Testing
    }

    public class TicketType
    {
        [Key]
        public int TypeId { get; set; }
        public int TicketId { get; set; }

        [Required]
        [Display(Name ="Type")]
        public TypeOfTicket? TypeOfTicket { get; set; }
    }
}