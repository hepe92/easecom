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

        internal async Task CreateCaseAsync(CaseCreateVM newCase)
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

        public async Task<CaseDetailsVM> GetCaseDetailsByIdAsync(int id)
        {
            return await context.
                CaseTable.
                Select(o => new CaseDetailsVM
                {
                    Id = o.Id,
                    Headline = o.Headline,
                    Description = o.Description,
                    Creator = o.Creator

                })

                .SingleOrDefaultAsync(e => e.Id == id);
        }

        internal async Task DeleteCaseByIdAsync(int id)
        {
            var caseToRemove = await context.CaseTable.Where(e => e.Id == id).FirstOrDefaultAsync();

            //var removeThisCase = await context.
            //    CaseTable.
            //    SingleOrDefaultAsync(e => e.Id == id);

             context.Remove(caseToRemove);

            await context.SaveChangesAsync();
        }


        public async Task<CaseEditVM> EditCaseAsync(CaseEditVM caseEdit)
        {
            return await context.CaseTable.Select(e => new CaseEditVM
            {
                Headline = e.Headline,
                Description = e.Description
            })
            .SingleOrDefaultAsync(o => o.Id == caseEdit.Id);
        }

        public async Task<CaseEditVM> GetEditDetailsByIdAsync(int id)
        {
            var b = await context.
                CaseTable.
                Select(o => new CaseEditVM
                {
                    Id = o.Id,
                    Headline = o.Headline,
                    Description = o.Description,
                    Creator = o.Creator
                })

                .SingleOrDefaultAsync(e => e.Id == id);
            return b;
        }
    }
}
