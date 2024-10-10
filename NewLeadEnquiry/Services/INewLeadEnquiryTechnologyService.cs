using DataServices.Models;

namespace NewLeadApi.Services
{
    public interface INewLeadEnquiryTechnologyService
    {
        public Task<IEnumerable<NewLeadEnquiryTechnologyDTO>> GetAll();
        public Task<NewLeadEnquiryTechnologyDTO> Get(string id);
        public Task<NewLeadEnquiryTechnologyDTO> Add(NewLeadEnquiryTechnologyDTO dto);
        public Task<NewLeadEnquiryTechnologyDTO> Update(NewLeadEnquiryTechnologyDTO dto);
        public Task<bool> Delete(string id);
    }
}
