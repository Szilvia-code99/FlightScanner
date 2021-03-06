using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        // Required -> specifies that a field value is required ; validation occurs only for fields that are submitted to the server
        // StringLength -> specifies the minimum and maximum length of characters that are allowed in a data field
        [Required(ErrorMessage = "Password is required !")]
        [StringLength(10, MinimumLength=4, ErrorMessage = "Password should be between 4 and 10 characters")]
        public string Password{get;set;}
         [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

         [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int IdNumber { get; set; }
    }
}