using System;
using System.Collections.Generic;

namespace Easecom.Models.Entities
{
    public partial class CaseTable
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        public string Headline { get; set; }
    }
}
