using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must give your ticket a subject.")]
        [MaxLength(255)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please provide a description for your ticket.")]
        public string Description { get; set; }

        [Required]
        public DateTime TimeOpened { get; set; }

        [Display(Name = "Time Assigned")]
        public DateTime? TimeAssigned { get; set; }

        [Display(Name = "Time Resolved")]
        public DateTime? TimeResolved { get; set; }

        [Required]
        [Display(Name = "Ticket Status")]
        public int StatusId { get; set; }

        public TicketStatusDto Status { get; set; }
    }
}