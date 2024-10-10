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
    public class NewLeadEnquiryRepository : IRepository<NewLeadEnquiry>
    {
        private readonly DataBaseContext _context;

        public NewLeadEnquiryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewLeadEnquiry>> GetAll()
        {
            return await _context.TblNewLeadEnquiry.ToListAsync();
        }

        public async Task<NewLeadEnquiry> Get(string id)
        {
            return await _context.TblNewLeadEnquiry.FindAsync(id);
        }

        public async Task<NewLeadEnquiry> Create(NewLeadEnquiry _object)
        {
            _context.TblNewLeadEnquiry.Add(_object);
            await _context.SaveChangesAsync();
            return _object;
        }

        public async Task<NewLeadEnquiry> Update(NewLeadEnquiry _object)
        {
            _context.Entry(_object).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _object;
        }

        public async Task<bool> Delete(string id)
        {
            var data = await _context.TblNewLeadEnquiry.FindAsync(id);
            if (data == null)
            {
                return false;
            }

            _context.TblNewLeadEnquiry.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
