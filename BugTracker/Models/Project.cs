using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string ProjectLeaderId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? ProjectedCompletionDate { get; set; }

        public DateTime? ActualCompletionDate { get; set; }

        [Required]
        [Display(Name="Project Status")]
        public int StatusId { get; set; }

        public ProjectStatus Status { get; set; }
    }
}