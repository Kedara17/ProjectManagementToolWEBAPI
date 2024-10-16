using DataServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLeadApi.Services;

namespace NewLeadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewLeadEnquiryDocumentsController : ControllerBase
    {
        private readonly INewLeadEnquiryDocumentsService _service;

        public NewLeadEnquiryDocumentsController(INewLeadEnquiryDocumentsService service)
        {
            _service = service;
        }

        // GET: api/NewLeadEnquiryDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewLeadEnquiryDocumentsDTO>>> GetAllDocuments()
        {
            var documents = await _service.GetAll();
            return Ok(documents);
        }

        // GET: api/NewLeadEnquiryDocuments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NewLeadEnquiryDocumentsDTO>> GetDocument(string id)
        {
            var document = await _service.Get(id);
            if (document == null)
            {
                return NotFound($"Document with ID {id} not found.");
            }
            return Ok(document);
        }

        // POST: api/NewLeadEnquiryDocuments
        [HttpPost]
        public async Task<ActionResult<NewLeadEnquiryDocumentsDTO>> AddDocument(NewLeadEnquiryDocumentsDTO documentDTO)
        {
            var createdDocument = await _service.Add(documentDTO);
            return CreatedAtAction(nameof(GetDocument), new { id = createdDocument.NewLeadEnquiryID }, createdDocument);
        }

        // PUT: api/NewLeadEnquiryDocuments/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<NewLeadEnquiryDocumentsDTO>> UpdateDocument(string id, NewLeadEnquiryDocumentsDTO documentDTO)
        {
            if (id != documentDTO.Id)
            {
                return BadRequest("Document ID mismatch.");
            }

            try
            {
                var updatedDocument = await _service.Update(documentDTO);
                return Ok(updatedDocument);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Document with ID {id} not found.");
            }
        }

        // DELETE: api/NewLeadEnquiryDocuments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(string id)
        {
            var result = await _service.Delete(id);
            if (!result)
            {
                return NotFound($"Document with ID {id} not found.");
            }
            return NoContent();
        }
    }
}