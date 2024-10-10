using DataServices.Data;
using DataServices.Models;
using DataServices.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NewLeadApi.Services
{
    public class NewLeadEnquiryTechnologyService : INewLeadEnquiryTechnologyService
    {
        private readonly IRepository<NewLeadEnquiryTechnology> _repository;
        private readonly DataBaseContext _context;

        public NewLeadEnquiryTechnologyService(IRepository<NewLeadEnquiryTechnology> repository, DataBaseContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<NewLeadEnquiryTechnologyDTO>> GetAll()
        {
            var technologies = await _repository.GetAll();
            return technologies.Select(t => new NewLeadEnquiryTechnologyDTO
            {
                TechnologyID = t.TechnologyID.ToString(),
                IsActive = t.IsActive,
                CreatedBy = t.CreatedBy,
                CreatedDate = t.CreatedDate,
                UpdatedBy = t.UpdatedBy,
                UpdatedDate = t.UpdatedDate
            });
        }

        public async Task<NewLeadEnquiryTechnologyDTO> Get(string id)
        {
            var technology = await _repository.Get(id);
            if (technology == null) return null;

            return new NewLeadEnquiryTechnologyDTO
            {
                TechnologyID = technology.TechnologyID.ToString(),
                IsActive = technology.IsActive,
                CreatedBy = technology.CreatedBy,
                CreatedDate = technology.CreatedDate,
                UpdatedBy = technology.UpdatedBy,
                UpdatedDate = technology.UpdatedDate
            };
        }

        public async Task<NewLeadEnquiryTechnologyDTO> Add(NewLeadEnquiryTechnologyDTO dto)
        {
            var newTechnology = new NewLeadEnquiryTechnology
            {
                NewLeadEnquiryID = dto.NewLeadEnquiryID,  // Set the NewLeadEnquiryID
                TechnologyID = dto.TechnologyID,
                IsActive = dto.IsActive,
                CreatedBy = dto.CreatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dto.UpdatedDate
            };

            await _repository.Create(newTechnology);
            return dto;
        }

        public async Task<NewLeadEnquiryTechnologyDTO> Update(NewLeadEnquiryTechnologyDTO dto)
        {
            var technology = await _repository.Get(dto.Id); // Use NewLeadEnquiryID for retrieval
            if (technology == null) throw new KeyNotFoundException("Technology not found.");

            technology.NewLeadEnquiryID = dto.NewLeadEnquiryID; // Update the foreign key
            technology.TechnologyID = dto.TechnologyID;
            technology.IsActive = dto.IsActive;
            technology.CreatedBy = dto.CreatedBy;
            technology.CreatedDate = dto.CreatedDate;
            technology.UpdatedBy = dto.UpdatedBy;
            technology.UpdatedDate = dto.UpdatedDate;

            await _repository.Update(technology);
            return dto;
        }


        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }
    }
}
