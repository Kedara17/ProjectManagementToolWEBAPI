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
    public class NewLeadEnquiryDocumentsRepository : IRepository<NewLeadEnquiryDocuments>
    {
        private readonly DataBaseContext _context;

        public NewLeadEnquiryDocumentsRepository(DataBaseContext context)
        {
            _context = context;
        }

        // Retrieve all documents
        public async Task<IEnumerable<NewLeadEnquiryDocuments>> GetAll()
        {
            return await _context.TblNewLeadEnquiryDocuments.ToListAsync();
        }

        // Retrieve a document by ID
        public async Task<NewLeadEnquiryDocuments> Get(string id)
        {
            return await _context.TblNewLeadEnquiryDocuments.FindAsync(id);
        }

        // Add a new document
        public async Task<NewLeadEnquiryDocuments> Create(NewLeadEnquiryDocuments document)
        {
            _context.TblNewLeadEnquiryDocuments.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }

        // Update an existing document
        public async Task<NewLeadEnquiryDocuments> Update(NewLeadEnquiryDocuments document)
        {
            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return document;
        }

        // Delete a document by ID
        public async Task<bool> Delete(string id)
        {
            var document = await _context.TblNewLeadEnquiryDocuments.FindAsync(id);
            if (document == null)
            {
                return false;
            }

            _context.TblNewLeadEnquiryDocuments.Remove(document);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
