using DataServices.Models;

namespace NewLeadApi.Services
{
    public interface INewLeadEnquiryDocumentsService
    {
        public Task<IEnumerable<NewLeadEnquiryDocumentsDTO>> GetAll();
        public Task<NewLeadEnquiryDocumentsDTO> Get(string id);
        public Task<NewLeadEnquiryDocumentsDTO> Add(NewLeadEnquiryDocumentsDTO dto);
        public Task<NewLeadEnquiryDocumentsDTO> Update(NewLeadEnquiryDocumentsDTO dto);
        public Task<bool> Delete(string id);
    }
}
