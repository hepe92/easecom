using Easecom.Models.Entities;
using Easecom.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easecom.Models
{
    public class CaseService
    {
        private readonly EasecomContext context;

        public CaseService(EasecomContext context)
        {
            this.context = context;
        }

        internal async Task AddCaseAsync(CaseCreateVM newCase)
        {
            context.CaseTable.Add(new CaseTable
            {
                Headline = newCase.Headline,
                Description = newCase.Description,
                Creator = newCase.Creator
            });
            await context.SaveChangesAsync();
        }

        public async Task<CaseIndexVM> GetAllCasesAsync()
        {
            return new CaseIndexVM
            {
                ItemVMs =
                await context.CaseTable
                .OrderBy(o => o.Headline)
                .Select(p => new CaseIndexItemVM
                {
                    Headline = p.Headline,
                    Description = p.Description,
                    Id = p.Id,
                    Creator = p.Creator
                })
                .ToArrayAsync()
            };
        }

        //public async Task<CaseDetailsVM> GetCaseDetails(int id)
        //{

        //}
    }
}
