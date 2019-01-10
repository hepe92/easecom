using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models.ViewModels
{
    public class CaseDetailsVM
    {
        public CaseFeedItemVM[] FeedItemVMs { get; set; }

        public int Id { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Description { get; set; }

        public string Creator { get; set; }

    }

    public class CaseFeedItemVM
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Message { get; set; }
        public string Creator { get; set; }
        public DateTime PostDateTime { get; set; }
        public bool IsUser { get; set; }
    }
}
