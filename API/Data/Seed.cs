using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data
{
    public  class Seed {
        
        public static async Task SeedUsers(DataContext context){
            //if (await context.Users.AnyAsync()) return;
        
     /*    var userData = await System.IO.File.ReadAllTextAsync("Data/myJsonFile0.json");
         var user = JsonSerializer.Deserialize<User>(userData);

         
             using var hmac = new HMACSHA512();
             user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
             user.PasswordSalt = hmac.Key;

             context.Users.Add(user);
             
         
         await context.SaveChangesAsync();*/
        }
    }
}