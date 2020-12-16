using System;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsuranceApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/clients/{clientId}/policies/{policyId}/claims")]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IClientRepository _clientRepository;

        private readonly ILogger<PoliciesController> _logger;
        private readonly IPolicyRepository _policyRepository;

        public ClaimsController(ILogger<PoliciesController> logger, IClientRepository clientRepository,
            IPolicyRepository policyRepository, IClaimRepository claimRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _policyRepository = policyRepository;
            _claimRepository = claimRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromRoute] Guid policyId)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            return Ok(await _claimRepository.GetClaims(policyId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            var claim = await _claimRepository.GetClaim(id);

            if (claim == null) return NotFound();

            return Ok(claim);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id,
            [FromBody] Claim claim)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            if (await _claimRepository.GetClaim(id) == null) return NotFound();

            await _claimRepository.UpdateClaim(claim);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid clientId, [FromRoute] Guid policyId,
            [FromBody] Claim claim)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            var addedClaim = await _claimRepository.AddClaim(policyId, claim);
            return CreatedAtAction(nameof(Get), new {clientId, policyId, id = addedClaim.Id}, addedClaim);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            if (await _claimRepository.GetClaim(id) == null) return NotFound();

            await _claimRepository.DeleteClaim(id);
            return NoContent();
        }

        [HttpOptions]
        public async Task<IActionResult> Options([FromRoute] Guid clientId, [FromRoute] Guid policyId)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            Response.Headers.Add("Allow", "GET,PUT,POST,DELETE,OPTIONS,HEAD");
            return Ok();
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> Head([FromRoute] Guid clientId, [FromRoute] Guid policyId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null ||
                await _policyRepository.GetPolicy(policyId) == null)
                return NotFound();

            if (await _claimRepository.GetClaim(id) == null) return NotFound();

            return Ok();
        }
    }
}