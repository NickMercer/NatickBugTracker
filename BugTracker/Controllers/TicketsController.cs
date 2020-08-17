using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BugTracker.View_Models;

namespace BugTracker.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext context;

        public TicketsController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = context.Tickets.Include(t => t.Status).ToList();

            return View(tickets);
        }

        // GET: Tickets/Details/Id
        public ActionResult Details(int id)
        {
            var ticket = context.Tickets.Include(t => t.Status).Where(x => x.Id == id).FirstOrDefault();

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            var viewModel = new TicketFormViewModel()
            {
                Statuses = context.TicketStatuses.ToList()
            };

            return View("TicketForm", viewModel);
        }

        // GET: Tickets/Edit/Id
        [Authorize(Roles = Roles.Admin + "," + Roles.Developer + "," + Roles.ProjectLead)]
        public ActionResult Edit(int id)
        {
            var ticket = context.Tickets.SingleOrDefault(t => t.Id == id);

            if (ticket == null)
                return HttpNotFound();

            var viewModel = new TicketFormViewModel(ticket)
            {
                Statuses = context.TicketStatuses.ToList()
            };

            return View("TicketForm", viewModel);
        }

        // POST: Tickets/Save/Ticket
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TicketFormViewModel(ticket)
                {
                    Statuses = context.TicketStatuses.ToList()
                };

                return View("TicketForm", viewModel);
            }

            if(ticket.Id == 0)
            {
                ticket.TimeOpened = DateTime.UtcNow;
                ticket.StatusId = 1;
                context.Tickets.Add(ticket);
            }
            else
            {
                var ticketInDb = context.Tickets.Single(t => t.Id == ticket.Id);

                ticketInDb.Subject = ticket.Subject;
                ticketInDb.Description = ticket.Description;
                ticketInDb.TimeAssigned = ticket.TimeAssigned;
                ticketInDb.TimeResolved = ticket.TimeResolved;
                ticketInDb.StatusId = ticket.StatusId;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Tickets");
        }

    }
}