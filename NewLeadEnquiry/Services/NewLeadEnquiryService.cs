using DataServices.Data;
using DataServices.Models;
using DataServices.Repositories;

namespace NewLeadApi.Services
{
    public class NewLeadEnquiryService : INewLeadEnquiryService
    {
        private readonly IRepository<NewLeadEnquiry> _repository;
        private readonly DataBaseContext _context;

        public NewLeadEnquiryService(IRepository<NewLeadEnquiry> repository, DataBaseContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<NewLeadEnquiryDTO>> GetAll()
        {
            var enquiries = await _repository.GetAll();
            return enquiries.Select(e => new NewLeadEnquiryDTO
            {
                CompanyName = e.CompanyName,
                CompanyRepresentative = e.CompanyRepresentative,
                RepresentativeDesignation = e.RepresentativeDesignation,
                Requirement = e.Requirement,
                EnquiryDate = e.EnquiryDate,
                Status = e.Status,
                Comments = e.Comments
            });
        }

        public async Task<NewLeadEnquiryDTO> Get(string id)
        {
            var enquiry = await _repository.Get(id);
            if (enquiry == null) return null;

            return new NewLeadEnquiryDTO
            {
                EmployeeID = enquiry.EmployeeID,
                AssignTo = enquiry.AssignTo,
                CompanyName = enquiry.CompanyName,
                CompanyRepresentative = enquiry.CompanyRepresentative,
                RepresentativeDesignation = enquiry.RepresentativeDesignation,
                Requirement = enquiry.Requirement,
                EnquiryDate = enquiry.EnquiryDate,
                Status = enquiry.Status,
                Comments = enquiry.Comments,
                IsActive = enquiry.IsActive,
                UpdatedBy = enquiry.UpdatedBy,
                UpdatedDate = enquiry.UpdatedDate
            };
        }

        public async Task<NewLeadEnquiryDTO> Add(NewLeadEnquiryDTO dto)
        {
            var newLeadEnquiry = new NewLeadEnquiry
            {
                CompanyName = dto.CompanyName,
                CompanyRepresentative = dto.CompanyRepresentative,
                RepresentativeDesignation = dto.RepresentativeDesignation,
                Requirement = dto.Requirement,
                EnquiryDate = dto.EnquiryDate,
                Status = dto.Status,
                Comments = dto.Comments
            };

            await _repository.Create(newLeadEnquiry);
            return dto;
        }

        public async Task<NewLeadEnquiryDTO> Update(NewLeadEnquiryDTO dto)
        {
            var enquiry = await _repository.Get(dto.Id);
            if (enquiry == null) throw new KeyNotFoundException("Lead Enquiry not found.");

            enquiry.CompanyName = dto.CompanyName;
            enquiry.CompanyRepresentative = dto.CompanyRepresentative;
            enquiry.RepresentativeDesignation = dto.RepresentativeDesignation;
            enquiry.Requirement = dto.Requirement;
            enquiry.EnquiryDate = dto.EnquiryDate;
            enquiry.Status = dto.Status;
            enquiry.Comments = dto.Comments;

            await _repository.Update(enquiry);
            return dto;
        }

        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }
    }
}
