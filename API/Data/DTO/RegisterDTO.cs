using System.ComponentModel.DataAnnotations;
using API.Controllers;

namespace API.Data.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get;set; }

    }
}