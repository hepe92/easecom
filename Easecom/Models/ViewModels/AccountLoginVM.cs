using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class AccountLoginVM
    {
        [Required(ErrorMessage = "Username does not exit")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Invalid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; internal set; }
    }
}
