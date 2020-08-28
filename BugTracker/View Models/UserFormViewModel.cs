using BugTracker.Dtos;
using BugTracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.View_Models
{
    public class UserFormViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public UserFormViewModel()
        {
        }

        public UserFormViewModel(ApplicationUser user, IEnumerable<string> roles, string currentRole)
        {
            Email = user.Email;
            UserName = user.UserName;
            Roles = roles;
            Role = currentRole;
        }
    }
}