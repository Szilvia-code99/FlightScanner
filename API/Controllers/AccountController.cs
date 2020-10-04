using API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using API.Entities;
using System.Text;
using API.Data.DTO;
using System.Linq;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _dataContext;

        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("register")]

        public async Task<ActionResult<User>> Register(RegisterDTO registerData){
        
        if (UserExists(registerData.userName)){
         return BadRequest();
        } else {

        using var hmac=new HMACSHA512();

        var user = new User{
            userName=registerData.userName,
            hash=hmac.ComputeHash(Encoding.UTF8.GetBytes(registerData.password)),
            salt=hmac.Key
        };

        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();
         
         return user;
         }
        }

        private bool UserExists(string username){
          return _dataContext.Users.Any(x => x.userName ==username.ToLower());
        }
    }
}