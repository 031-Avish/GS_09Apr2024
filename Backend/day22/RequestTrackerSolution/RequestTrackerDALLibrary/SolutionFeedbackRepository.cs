﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
     public class SolutionFeedbackRepository:IRepository<int,SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;
        public SolutionFeedbackRepository(RequestTrackerContext context) {
            _context = context;
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> DeleteByKey(int key)
        {
            var solutionFeedback = await GetByKey(key);
            if (solutionFeedback != null)
            {
                _context.SolutionFeedbacks.Remove(solutionFeedback);
                await _context.SaveChangesAsync();
            }
            return solutionFeedback;

        }

        public async Task<SolutionFeedback> GetByKey(int key)
        {
            var solutionFeedback = _context.SolutionFeedbacks.SingleOrDefault(e => e.FeedbackId == key);
            return solutionFeedback;

        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.SolutionFeedbacks.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var solutionFeedback = await GetByKey(entity.FeedbackId);
            if (solutionFeedback != null)
            {
                _context.Entry<SolutionFeedback>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
