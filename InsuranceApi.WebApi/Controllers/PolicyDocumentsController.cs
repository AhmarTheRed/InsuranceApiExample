using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsuranceApi.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/clients/{clientId}/policies/{policyId}/documents")]
    public class PolicyDocumentsController : ControllerBase
    {

        private readonly ILogger<PoliciesController> _logger;
        private readonly IClientRepository _clientRepository;
        private readonly IPolicyRepository _policyRepository;
        private readonly IDocumentRepository _documentRepository;

        public PolicyDocumentsController(ILogger<PoliciesController> logger, IClientRepository clientRepository, IPolicyRepository policyRepository, IDocumentRepository documentRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _policyRepository = policyRepository;
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromRoute] Guid policyId)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            return Ok(await _documentRepository.GetDocumentsForPolicy(policyId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            var document = await _documentRepository.GetDocument(id);

            if (document == null) return NotFound();

            return Ok(document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id, [FromBody] Document document)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            if (await _documentRepository.GetDocument(id) == null) return NotFound();

            await _documentRepository.UpdateDocument(document);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid clientId, [FromRoute] Guid policyId, [FromBody] Document document)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            var addedDocument = await _documentRepository.AddDocumentToPolicy(policyId, document);
            return CreatedAtAction(nameof(Get), new { clientId = clientId, policyId = policyId, id = addedDocument.Id }, addedDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            if (await _documentRepository.GetDocument(id) == null) return NotFound();

            await _documentRepository.DeleteDocument(id);
            return NoContent();
        }

        [HttpOptions]
        public async Task<IActionResult> Options([FromRoute] Guid clientId, [FromRoute] Guid policyId)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            Response.Headers.Add("Allow", "GET,PUT,POST,DELETE,OPTIONS,HEAD");
            return Ok();
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> Head([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null || await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            if (await _documentRepository.GetDocument(id) == null) return NotFound();

            return Ok();
        }
    }
}
