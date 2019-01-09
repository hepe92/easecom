﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class CaseEditVM
    {

        public int Id { get; set; }

        [Required]
        public string Headline { get; set; }

        [Required]
        public string Description { get; set; }


        public string Creator { get; set; }
    }
}
