using System;
using System.Collections.Generic;

namespace Easecom.Models.Entities
{
    public partial class CaseTable
    {
        public CaseTable()
        {
            CaseFeed = new HashSet<CaseFeed>();
        }

        public int Id { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        public string Headline { get; set; }

        public virtual ICollection<CaseFeed> CaseFeed { get; set; }
    }
}
