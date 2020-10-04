using API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using API.Entities;
using System.Text;
using API.Data.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _dataContext;

        private readonly ITokenService _tokenService;

        public AccountController(DataContext dataContext,ITokenService tokenService)
        {
            _dataContext = dataContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]

        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerData){
        
        if (await UserExists(registerData.userName)){
         return BadRequest("Username already registered");
        } 

        using var hmac=new HMACSHA512();

        var user = new User{
            userName=registerData.userName,
            hash=hmac.ComputeHash(Encoding.UTF8.GetBytes(registerData.password)),
            salt=hmac.Key
        };

        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();
         
         return new UserDTO{
             userName = user.userName,
             token = _tokenService.CreateToken(user)
         };
         
        }

        private async Task<bool> UserExists(string username){
          return await _dataContext.Users.AnyAsync(x => x.userName.ToLower() == username.ToLower());
        }

        
        [HttpPost("login")]

        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginData){
        
        var user= await _dataContext.Users
        .FirstOrDefaultAsync(x => x.userName == loginData.userName);

        if (user == null){
         return Unauthorized("Invalid username");
        } 

        using var hmac=new HMACSHA512(user.salt);

        var computedHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(loginData.password));

        for( int i=0;i<computedHash.Length;i++){
            if (computedHash[i] != user.hash[i]) {
                return Unauthorized("Invalid password or username");
            }
        }
       
         return new UserDTO{
             userName=user.userName,
             token=_tokenService.CreateToken(user)
         };
        }
    }
}