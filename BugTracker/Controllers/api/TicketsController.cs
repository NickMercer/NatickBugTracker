using AutoMapper;
using BugTracker.Dtos;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BugTracker.Controllers.api
{
    public class TicketsController : ApiController
    {
        private readonly ApplicationDbContext context;

        public TicketsController()
        {
            context = new ApplicationDbContext();
        }

        public IHttpActionResult GetTickets()
        {
            var ticketsDtos = context.Tickets.Include(t => t.Status).ToList().Select(Mapper.Map<Ticket, TicketDto>);

            return Ok(ticketsDtos);
        }

        public IHttpActionResult GetTicket(int id)
        {
            var ticket = context.Tickets.SingleOrDefault(x => x.Id == id);

            if(ticket == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Ticket, TicketDto>(ticket));
        }

        [HttpPost]
        public IHttpActionResult CreateTicket(TicketDto ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ticket = Mapper.Map<TicketDto, Ticket>(ticketDto);
            context.Tickets.Add(ticket);
            context.SaveChanges();

            ticketDto.Id = ticket.Id;

            return Created(new Uri(Request.RequestUri + "/" + ticket.Id), ticketDto);
        }

        [HttpPost]
        public void UpdateTicket(int id, TicketDto ticketDto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var ticketInDb = context.Tickets.SingleOrDefault(t => t.Id == id);

            if(ticketInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(ticketDto, ticketInDb);

            context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var ticketInDb = context.Tickets.SingleOrDefault(t => t.Id == id);

            if(ticketInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Tickets.Remove(ticketInDb);
            context.SaveChanges();
        }
    }
}
