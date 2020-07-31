using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Subject { get; set; }

        [Required]
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

        public TicketStatus Status { get; set; }
    }
}