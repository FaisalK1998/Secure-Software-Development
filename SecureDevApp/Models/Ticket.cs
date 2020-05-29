using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureDevApp.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200, ErrorMessage ="The ticket description cannot be longer than 200 characters")]
        [RegularExpression(@"^[a-zA-Z0-9.,""\s-]*$", ErrorMessage ="You have entered characters which are not allowed.")]
        public string TicketDescription { get; set; }

        [Required]
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Time Stamp")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Display(Name = "Name of Bug Founder")]
        [StringLength(25, ErrorMessage ="The bug founder name cannot be longer than 25 characters")]
        [RegularExpression(@"^[a-zA-Z""\s-]*$", ErrorMessage = "You have entered characters which are not allowed.")]
        public string NameOfFounder { get; set; }

        [Required]
        [Display(Name = "Assigned Developer")]
        [StringLength(25, ErrorMessage = "The assigned developer's name cannot be longer than 25 characters")]
        [RegularExpression(@"^[a-zA-Z""\s-]*$", ErrorMessage = "You have entered characters which are not allowed.")]
        public string AssignedDeveloper { get; set; }

        [Required]
        [Display(Name = "Type")]
        public TicketType TicketType { get; set; }
        public int TicketTypeId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public TicketStatus TicketStatus { get; set; }
        public int TicketStatusId { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public TicketPriority TicketPriority { get; set; }
        public int TicketPriorityId { get; set; }

        public virtual Comment Comment { get; set; }

    }
}