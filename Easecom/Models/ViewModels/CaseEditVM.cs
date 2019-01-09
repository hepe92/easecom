using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class CaseEditVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Headline { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Creator { get; set; }
    }
}
