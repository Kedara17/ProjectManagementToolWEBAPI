using DataServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLeadApi.Services;

namespace NewLeadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewLeadEnquiryController : ControllerBase
    {
        private readonly INewLeadEnquiryService _service;
        private readonly ILogger<NewLeadEnquiryController> _logger;

        public NewLeadEnquiryController(INewLeadEnquiryService service, ILogger<NewLeadEnquiryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Director, Project Manager, Team Lead, Team Member")]
        public async Task<ActionResult<IEnumerable<NewLeadEnquiry>>> GetAll()
        {
            _logger.LogInformation("Fetching all new lead enquiries");
            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Director, Project Manager, Team Lead, Team Member")]
        public async Task<ActionResult<NewLeadEnquiry>> Get(string id)
        {
            _logger.LogInformation("Fetching new lead enquiry with id: {Id}", id);
            var data = await _service.Get(id);

            if (data == null)
            {
                _logger.LogWarning("New lead enquiry with id: {Id} not found", id);
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Director, Project Manager")]
        public async Task<IActionResult> Add(NewLeadEnquiryDTO _object)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating new lead enquiry");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Creating a new lead enquiry");
            try
            {
                var created = await _service.Add(_object);
                return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Director, Project Manager, Team Lead")]
        public async Task<IActionResult> Update(string id, [FromBody] NewLeadEnquiryDTO _object)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating new lead enquiry");
                return BadRequest(ModelState);
            }

            if (id != _object.Id)
            {
                _logger.LogWarning("New lead enquiry id: {Id} does not match with the id in the request body", id);
                return BadRequest("New lead enquiry ID mismatch.");
            }

            _logger.LogInformation("Updating new lead enquiry with id: {Id}", id);
            try
            {
                await _service.Update(_object);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("Attempting to delete new lead enquiry with id: {Id}", id);

            try
            {
                var success = await _service.Delete(id);

                if (!success)
                {
                    _logger.LogWarning("New lead enquiry with id: {Id} not found", id);
                    return NotFound(new { message = $"New lead enquiry with id {id} not found." });
                }

                _logger.LogInformation("Successfully deleted new lead enquiry with id: {Id}", id);
                return Ok(new { message = $"New lead enquiry with id {id} deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting new lead enquiry with id: {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while deleting the new lead enquiry." });
            }
        }
    }
}
