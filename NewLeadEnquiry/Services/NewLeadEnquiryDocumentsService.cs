using DataServices.Data;
using DataServices.Models;
using DataServices.Repositories;

namespace NewLeadApi.Services
{
    public class NewLeadEnquiryDocumentsService : INewLeadEnquiryDocumentsService
    {
        private readonly IRepository<NewLeadEnquiryDocuments> _repository;
        private readonly DataBaseContext _context;

        public NewLeadEnquiryDocumentsService(IRepository<NewLeadEnquiryDocuments> repository, DataBaseContext context)
        {
            _repository = repository;
            _context = context;
        }

        // Get all documents
        public async Task<IEnumerable<NewLeadEnquiryDocumentsDTO>> GetAll()
        {
            var documents = await _repository.GetAll();
            return documents.Select(doc => new NewLeadEnquiryDocumentsDTO
            {
                NewLeadEnquiryID = doc.NewLeadEnquiryID,
                FileName = doc.FileName,
                IsActive = doc.IsActive,
                CreatedBy = doc.CreatedBy,
                CreatedDate = doc.CreatedDate,
                UpdatedBy = doc.UpdatedBy,
                UpdatedDate = doc.UpdatedDate
            });
        }

        // Get a document by ID
        public async Task<NewLeadEnquiryDocumentsDTO> Get(string id)
        {
            var document = await _repository.Get(id);
            if (document == null) return null;

            return new NewLeadEnquiryDocumentsDTO
            {
                NewLeadEnquiryID = document.NewLeadEnquiryID,
                FileName = document.FileName,
                IsActive = document.IsActive,
                CreatedBy = document.CreatedBy,
                CreatedDate = document.CreatedDate,
                UpdatedBy = document.UpdatedBy,
                UpdatedDate = document.UpdatedDate
            };
        }

        // Add a new document
        public async Task<NewLeadEnquiryDocumentsDTO> Add(NewLeadEnquiryDocumentsDTO dto)
        {
            var newDocument = new NewLeadEnquiryDocuments
            {
                NewLeadEnquiryID = dto.NewLeadEnquiryID,
                FileName = dto.FileName,
                IsActive = dto.IsActive,
                CreatedBy = dto.CreatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dto.UpdatedDate
            };

            await _repository.Create(newDocument);
            return dto;
        }

        // Update an existing document
        public async Task<NewLeadEnquiryDocumentsDTO> Update(NewLeadEnquiryDocumentsDTO dto)
        {
            var document = await _repository.Get(dto.Id);
            if (document == null) throw new KeyNotFoundException("Document not found.");

            document.FileName = dto.FileName;
            document.IsActive = dto.IsActive;
            document.CreatedBy = dto.CreatedBy;
            document.CreatedDate = dto.CreatedDate;
            document.UpdatedBy = dto.UpdatedBy;
            document.UpdatedDate = dto.UpdatedDate;

            await _repository.Update(document);
            return dto;
        }

        // Delete a document
        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }
    }
}
