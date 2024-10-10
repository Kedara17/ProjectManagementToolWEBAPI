using DataServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLeadApi.Services;

namespace NewLeadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewLeadEnquiryFollowupController : ControllerBase
    {
        private readonly INewLeadEnquiryFollowupService _followupService;

        public NewLeadEnquiryFollowupController(INewLeadEnquiryFollowupService followupService)
        {
            _followupService = followupService;
        }

        // GET: api/NewLeadEnquiryFollowup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewLeadEnquiryFollowupDTO>>> GetAll()
        {
            var followups = await _followupService.GetAll();
            return Ok(followups);
        }

        // GET: api/NewLeadEnquiryFollowup/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NewLeadEnquiryFollowupDTO>> Get(string id)
        {
            var followup = await _followupService.Get(id);
            if (followup == null)
            {
                return NotFound();
            }

            return Ok(followup);
        }

        // POST: api/NewLeadEnquiryFollowup
        [HttpPost]
        public async Task<ActionResult<NewLeadEnquiryFollowupDTO>> Add([FromBody] NewLeadEnquiryFollowupDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFollowup = await _followupService.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = createdFollowup.NewLeadEnquiryID }, createdFollowup);
        }

        // PUT: api/NewLeadEnquiryFollowup/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] NewLeadEnquiryFollowupDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _followupService.Update(dto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/NewLeadEnquiryFollowup/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _followupService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}