using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
      [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
       
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User> > GetUser()
        {
          return _dataContext.users.ToList();
        }
    }
}
