using System;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsuranceApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/clients/{clientId}/policies/{policyId}/claims/{claimId}/documents")]
    public class ClaimDocumentsController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDocumentRepository _documentRepository;

        private readonly ILogger<PoliciesController> _logger;
        private readonly IPolicyRepository _policyRepository;

        public ClaimDocumentsController(ILogger<PoliciesController> logger, IClientRepository clientRepository,
            IPolicyRepository policyRepository, IClaimRepository claimRepository,
            IDocumentRepository documentRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _policyRepository = policyRepository;
            _claimRepository = claimRepository;
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            return Ok(await _documentRepository.GetDocumentsForClaim(claimId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            var document = await _documentRepository.GetDocument(id);

            if (document == null) return NotFound();

            return Ok(document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId, Guid id, [FromBody] Document document)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            if (await _documentRepository.GetDocument(id) == null) return NotFound();

            await _documentRepository.UpdateDocument(document);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId, [FromBody] Document document)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            var addedDocument = await _documentRepository.AddDocumentToClaim(claimId, document);
            return CreatedAtAction(nameof(Get), new {clientId, policyId, claimId, id = addedDocument.Id},
                addedDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            if (await _documentRepository.GetDocument(id) == null) return NotFound();

            await _documentRepository.DeleteDocument(id);
            return NoContent();
        }

        [HttpOptions]
        public async Task<IActionResult> Options([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            Response.Headers.Add("Allow", "GET,PUT,POST,DELETE,OPTIONS,HEAD");
            return Ok();
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> Head([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromRoute] Guid claimId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null || await _claimRepository.GetClaim(claimId) == null)
                return NotFound();

            if (await _documentRepository.GetDocument(id) == null) return NotFound();

            return Ok();
        }
    }
}