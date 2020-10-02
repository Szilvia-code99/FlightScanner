using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO
{
    public class LoginDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get;set; }

        
    }
}