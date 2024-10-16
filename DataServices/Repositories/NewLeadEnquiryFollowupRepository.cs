using DataServices.Data;
using DataServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Repositories
{
    public class NewLeadEnquiryFollowupRepository : IRepository<NewLeadEnquiryFollowup>
    {
        private readonly DataBaseContext _context;

        public NewLeadEnquiryFollowupRepository(DataBaseContext context)
        {
            _context = context;
        }

        // Get all NewLeadEnquiryFollowups
        public async Task<IEnumerable<NewLeadEnquiryFollowup>> GetAll()
        {
            // Including related entities: NewLeadEnquiry and Employee
            return await _context.TblNewLeadEnquireFollowup
                                 .Include(f => f.NewLeadEnquiry)
                                 .Include(f => f.Employee)
                                 .ToListAsync();
        }

        // Get a specific NewLeadEnquiryFollowup by id
        public async Task<NewLeadEnquiryFollowup> Get(string id)
        {
            // Including related entities: NewLeadEnquiry and Employee
            return await _context.TblNewLeadEnquireFollowup
                                 .Include(f => f.NewLeadEnquiry)
                                 .Include(f => f.Employee)
                                 .FirstOrDefaultAsync(f => f.Id == id);
        }

        // Create a new NewLeadEnquiryFollowup
        public async Task<NewLeadEnquiryFollowup> Create(NewLeadEnquiryFollowup _object)
        {
            _context.TblNewLeadEnquireFollowup.Add(_object);
            await _context.SaveChangesAsync();
            return _object;
        }

        // Update an existing NewLeadEnquiryFollowup
        public async Task<NewLeadEnquiryFollowup> Update(NewLeadEnquiryFollowup _object)
        {
            _context.Entry(_object).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _object;
        }

        // Delete a NewLeadEnquiryFollowup by id
        public async Task<bool> Delete(string id)
        {
            var data = await _context.TblNewLeadEnquireFollowup.FindAsync(id);
            if (data == null)
            {
                return false;
            }

            _context.TblNewLeadEnquireFollowup.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
