using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureDevApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TicketId { get; set; }
        public string Comments { get; set; }
        public DateTime CommentTimeStamp { get; set; }
        
    }
}