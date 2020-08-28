using BugTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BugTracker.Dtos;

namespace BugTracker.Controllers.api
{
    public class PeopleController : ApiController
    {
        private readonly ApplicationDbContext context;

        public PeopleController()
        {
            context = new ApplicationDbContext();
        }


        public IHttpActionResult GetPeople()
        {
            var users = UsersWithRoles();

            return Ok(users);
        }

        private List<UserDto> UsersWithRoles()
        {
            var usersWithRoles = (from user in context.Users
                                  select new
                                  {
                                      Id = user.Id,
                                      UserName = user.UserName,
                                      RoleName = (from userRole in user.Roles
                                                  join role in context.Roles on userRole.RoleId
                                                  equals role.Id
                                                  select role.Name).FirstOrDefault()
                                  }).ToList().Select(p => new UserDto() { Id = p.Id, UserName = p.UserName, Role = p.RoleName });


            return usersWithRoles.ToList();

        }
    }
}
