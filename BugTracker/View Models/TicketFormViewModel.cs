using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.View_Models
{
    public class TicketFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Time Assigned")]
        public DateTime? TimeAssigned { get; set; }

        [Display(Name = "Time Resolved")]
        public DateTime? TimeResolved { get; set; }

        [Display(Name = "Ticket Status")]
        public int? StatusId { get; set; }


        public IEnumerable<TicketStatus> Statuses { get; set; }
        public string Title
        {
            get
            {
                if (IsNewTicket)
                {
                    return "New Ticket";
                }
                else
                {
                    return "Edit Ticket";
                }
            }
        }
        public bool IsNewTicket
        {
            get
            {
                return (Id == 0);
            }
        }

        public TicketFormViewModel()
        {
            Id = 0;
            StatusId = 0;
        }

        public TicketFormViewModel(Ticket ticket)
        {
            Id = ticket.Id;
            Subject = ticket.Subject;
            Description = ticket.Description;
            TimeAssigned = ticket.TimeAssigned;
            TimeResolved = ticket.TimeResolved;
            StatusId = ticket.StatusId;
        }
    }
}