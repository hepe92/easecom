using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class CaseCreateVM
    {
        [Display(Name = "Headline")]
        [Required(ErrorMessage = "Enter a headline")]
        public string Headline { get; set; }

        [Required(ErrorMessage = "Enter a Description")]
        public string Description { get; set; }

        public string Creator { get; set; }
    }
}
