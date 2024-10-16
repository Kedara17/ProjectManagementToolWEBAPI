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
    public class NewLeadEnquiryTechnologyRepository : IRepository<NewLeadEnquiryTechnology>
    {
        private readonly DataBaseContext _context;

        public NewLeadEnquiryTechnologyRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewLeadEnquiryTechnology>> GetAll()
        {
            return await _context.TblNewLeadEnquiryTechnology.ToListAsync();
        }

        public async Task<NewLeadEnquiryTechnology> Get(string id)
        {
            return await _context.TblNewLeadEnquiryTechnology.FindAsync(id);
        }

        public async Task<NewLeadEnquiryTechnology> Create(NewLeadEnquiryTechnology _object)
        {
            _context.TblNewLeadEnquiryTechnology.Add(_object);
            await _context.SaveChangesAsync();
            return _object;
        }

        public async Task<NewLeadEnquiryTechnology> Update(NewLeadEnquiryTechnology _object)
        {
            _context.Entry(_object).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _object;
        }

        public async Task<bool> Delete(string id)
        {
            var data = await _context.TblNewLeadEnquiryTechnology.FindAsync(id);
            if (data == null)
            {
                return false;
            }

            _context.TblNewLeadEnquiryTechnology.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
