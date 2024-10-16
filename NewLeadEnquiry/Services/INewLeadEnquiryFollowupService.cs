using DataServices.Models;

namespace NewLeadApi.Services
{
    public interface INewLeadEnquiryFollowupService
    {
        public Task<IEnumerable<NewLeadEnquiryFollowupDTO>> GetAll();
        public Task<NewLeadEnquiryFollowupDTO> Get(string id);
        public Task<NewLeadEnquiryFollowupDTO> Add(NewLeadEnquiryFollowupDTO dto);
        public Task<NewLeadEnquiryFollowupDTO> Update(NewLeadEnquiryFollowupDTO dto);
        public Task<bool> Delete(string id);
    }
}
