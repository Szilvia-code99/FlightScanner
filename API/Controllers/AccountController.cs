using API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using API.Entities;
using System.Text;
using API.Data.DTO;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using AutoMapper;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _dataContext;

        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;
        public AccountController(DataContext dataContext,ITokenService tokenService,IMapper mapper)
        {
            _dataContext = dataContext;
            _tokenService = tokenService;
            _mapper = mapper;
            

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerData) 
        {
            if (await UserExists(registerData.UserName)) {
                return BadRequest("Username already registered");
            } 
          
           var user = _mapper.Map<User>(registerData);
            using var hmac = new HMACSHA512();

                user.UserName = registerData.UserName;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerData.Password));
                user.PasswordSalt = hmac.Key;
                user.FirstName=registerData.FirstName;
                user.LastName=registerData.LastName;
                user.DateOfBirth=registerData.DateOfBirth;
                user.IdNumber=registerData.IdNumber;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
         
            return new UserDTO{
               userName = user.UserName,
               token = _tokenService.CreateToken(user)
            };         
        }

        private async Task<bool> UserExists(string username){
          return await _dataContext.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }

        
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginData)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == loginData.userName);

            if (user == null) {
                return Unauthorized("Invalid username");
            } 

            using var hmac=new HMACSHA512(user.PasswordSalt);

            var computedHash= hmac.ComputeHash(Encoding.UTF8.GetBytes(loginData.password));

            for(int i=0; i < computedHash.Length; i++){
                if (computedHash[i] != user.PasswordHash[i]) {
                    return Unauthorized("Invalid password or username");
                }
            }
       
            return new UserDTO{
                userName = user.UserName,
                token = _tokenService.CreateToken(user)
            };
        }
    }
}