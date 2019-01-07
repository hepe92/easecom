using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class AccountCreateVM
    {
        [Required(ErrorMessage ="Username needed")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password needed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
