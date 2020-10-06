using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [AllowAnonymous] // allow access by non-authenticated users to individual actions.
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          return await _dataContext.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize] // limits access to this method to any authenticated user
        public async Task<ActionResult<User>> GetUser(int id) 
        {
          return await _dataContext.Users.FindAsync(id);
        }

        // [AllowAnonymous] bypasses all authorization statements. If you combine [AllowAnonymous] and any [Authorize] attribute,
        // the [Authorize] attributes are ignored. For example if you apply [AllowAnonymous] at the controller level, any [Authorize] 
        // attributes on the same controller (or on any action within it) is ignored.
    }
}
