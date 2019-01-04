using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class CaseIndexVM
    {
        public CaseIndexItemVM[] ItemVMs { get; set; }
    }
    public class CaseIndexItemVM
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public int Id { get; set; }
    }
}
