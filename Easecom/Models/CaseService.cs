﻿using Easecom.Models.Entities;
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
                .OrderByDescending(o => o.Id)
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
            
            var detail =  await context.
                CaseTable.
                Select(o => new CaseDetailsVM
                {
                    Id = o.Id,
                    Headline = o.Headline,
                    Description = o.Description,
                    Creator = o.Creator
                    
                })

                .SingleOrDefaultAsync(e => e.Id == id);
            detail.FeedItemVMs = GetFeedItems(id);
            return detail;
        }

        private CaseFeedItemVM[] GetFeedItems(int id)
        {
            return context.CaseFeed.Where(o => o.CaseId == id).Select(o => new CaseFeedItemVM
            {
                Creator = o.Creator,
                Message = o.Message,
                CaseId = o.CaseId,
                Id=o.Id
                
            })
            .ToArray();
            
        }
        internal async Task CreateFeedMessageAsync(CaseFeedItemVM newFeedMessage)
        {
            context.CaseFeed.Add(new CaseFeed
            {
                Message = newFeedMessage.Message,
                CaseId = newFeedMessage.CaseId,
                Creator= newFeedMessage.Creator,
                PostDateTime = newFeedMessage.PostDateTime,
            });
            await context.SaveChangesAsync();
        }
        internal async Task DeleteCaseByIdAsync(int id)
        {

            await context.CaseFeed.Where(e => e.CaseId == id).ToArrayAsync();
            var caseToRemove = await context.CaseTable.Where(e => e.Id == id).FirstOrDefaultAsync();

            context.Remove(caseToRemove);
            await context.SaveChangesAsync();
        }


        public async Task EditCaseAsync(CaseEditVM editedCase)
        {
            var a = await context.CaseTable.FindAsync(editedCase.Id);
            a.Creator = editedCase.Creator;
            a.Headline = editedCase.Headline;
            a.Id = editedCase.Id;
            a.Description = editedCase.Description;

            await context.SaveChangesAsync();

        }
    }



}



