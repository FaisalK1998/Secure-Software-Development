using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureDevApp.Models
{
    public class TicketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var tickets = new List<Ticket>
            {
                new Ticket{Id=1, TicketDescription="Logic Error", DateCreated=DateTime.Parse("2019-11-30"), TimeStamp=DateTime.Parse("18:56:22"), NameOfFounder="Edward", AssignedDeveloper="George"}
            };
            tickets.ForEach(t => context.Tickets.Add(t));
            context.SaveChanges();

            var ticketStatus = new List<TicketStatus>
            {
                new TicketStatus{StatusId=1, StatusOfTicket=StatusOfTicket.Open}
            };
            ticketStatus.ForEach(t => context.TicketStatuses.Add(t));
            context.SaveChanges();

            var ticketType = new List<TicketType>
            {
                new TicketType{TypeId=1, TypeOfTicket=TypeOfTicket.Development}
            };
            ticketType.ForEach(t => context.TicketTypes.Add(t));
            context.SaveChanges();

            var ticketPriority = new List<TicketPriority>
            {
                new TicketPriority{PriorityId=1, PriorityOfTicket=PriorityOfTicket.High}
            };
            ticketPriority.ForEach(t => context.TicketPriorities.Add(t));
            context.SaveChanges();

            var comment = new List<Comment>
            {
                new Comment{CommentId=1, CommentTimeStamp=DateTime.Parse("19:22:20"), Comments="This is a Comment"}
            };
            comment.ForEach(t => context.Comments.Add(t));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}