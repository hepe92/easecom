using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class CreateFeedPostVM
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Creator { get; set; }
        public int CaseId { get; set; }

    }
}
