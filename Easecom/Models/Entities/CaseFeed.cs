using System;
using System.Collections.Generic;

namespace Easecom.Models.Entities
{
    public partial class CaseFeed
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Creator { get; set; }
        public string Message { get; set; }
        public DateTime? PostDateTime { get; set; }

        public virtual CaseTable Case { get; set; }
    }
}
