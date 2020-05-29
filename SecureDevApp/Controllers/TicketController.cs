using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecureDevApp.Models;

namespace SecureDevApp.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();   

        // GET: Ticket
        /// <summary>
        /// Gets a list of tickets from the Tickets entity set
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string sortOrder)
        {
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewBag.DescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "des_desc" : "";

            var tickets = from t in db.Tickets select t;

            switch (sortOrder)
            {
                case "Id_desc":
                    tickets = tickets.OrderByDescending(s => s.Id);
                    break;
                case "des_desc":
                    tickets = tickets.OrderByDescending(t => t.TicketDescription);
                    break;
                default:
                    tickets = tickets.OrderBy(t => t.Id);
                    break;
            }

            return View(db.Tickets.ToList());
            
        }
    

        // GET: Ticket/Details/5
        /// <summary>
        /// Returns the details from the Tickets entity set
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Adds the Ticket entity created by the model binder to the Tickets entity set
        /// and then saves the changes to the database
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageTickets)]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Allows an authenticated user to edit a ticket
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ticketToUpdate</returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ticketToUpdate = db.Tickets.Find(id);
            if (TryUpdateModel(ticketToUpdate, ""))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(DataException)
                {
                    //Log the error
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");

                }

            }

            return View(ticketToUpdate);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        /// <summary>
        /// Allows an authenticated user to delete a ticket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Ticket ticket = db.Tickets.Find(id);
                db.Tickets.Remove(ticket);
                db.SaveChanges();
            }
            catch(DataException)
            {
                //Log the error
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Closes database connections and free's up resources
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
