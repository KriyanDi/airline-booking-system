using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAbsApi.Data;

namespace WebAbsApi.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to", MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class UserDTO : LoginUserDTO
    {
        public ICollection<string> Roles { get; set; }
        //public ICollection<TicketDTO> Tickets { get; set; }
    }
}
