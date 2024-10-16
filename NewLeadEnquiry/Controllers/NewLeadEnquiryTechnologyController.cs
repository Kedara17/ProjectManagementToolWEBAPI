using DataServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLeadApi.Services;

namespace NewLeadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewLeadEnquiryTechnologyController : ControllerBase
    {
        private readonly INewLeadEnquiryTechnologyService _service;

        public NewLeadEnquiryTechnologyController(INewLeadEnquiryTechnologyService service)
        {
            _service = service;
        }

        // GET: api/NewLeadEnquiryTechnology
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewLeadEnquiryTechnologyDTO>>> GetAll()
        {
            var technologies = await _service.GetAll();
            return Ok(technologies);
        }

        // GET: api/NewLeadEnquiryTechnology/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NewLeadEnquiryTechnologyDTO>> Get(string id)
        {
            var technology = await _service.Get(id);
            if (technology == null)
            {
                return NotFound();
            }
            return Ok(technology);
        }

        [HttpPost]
        public async Task<ActionResult<NewLeadEnquiryTechnologyDTO>> Add([FromBody] NewLeadEnquiryTechnologyDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTechnology = await _service.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = createdTechnology.NewLeadEnquiryID }, createdTechnology);
        }

        // Adjust Update method
        [HttpPut("{id}")]
        public async Task<ActionResult<NewLeadEnquiryTechnologyDTO>> Update(string id, [FromBody] NewLeadEnquiryTechnologyDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.Id)  // Ensure the ID matches
            {
                return BadRequest("ID mismatch.");
            }

            try
            {
                var updatedTechnology = await _service.Update(dto);
                return Ok(updatedTechnology);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        // DELETE: api/NewLeadEnquiryTechnology/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var success = await _service.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok(success);
        }
    }
}