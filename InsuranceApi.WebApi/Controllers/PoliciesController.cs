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
    [ApiController]
    [Route("api/clients/{clientId}/policies")]
    public class PoliciesController : ControllerBase
    {

        private readonly ILogger<PoliciesController> _logger;
        private readonly IClientRepository _clientRepository;
        private readonly IPolicyRepository _policyRepository;

        public PoliciesController(ILogger<PoliciesController> logger, IClientRepository clientRepository, IPolicyRepository policyRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _policyRepository = policyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, [FromQuery] PaginationParameters pagination)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            return Ok(await _policyRepository.GetPolicies(clientId, pagination));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid clientId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            var policy = await _policyRepository.GetPolicy(id);

            if (policy == null) return NotFound();

            return Ok(policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid clientId, Guid id, [FromBody] Policy policy)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            if (await _policyRepository.GetPolicy(id) == null) return NotFound();

            await _policyRepository.UpdatePolicy(policy);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid clientId, [FromBody] Policy policy)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            var addedPolicy = await _policyRepository.AddPolicy(clientId, policy);
            return CreatedAtAction(nameof(Get), new { clientId = clientId, id = addedPolicy.Id }, addedPolicy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid clientId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            if (await _policyRepository.GetPolicy(id) == null) return NotFound();

            await _policyRepository.DeletePolicy(id);
            return NoContent();
        }

        [HttpOptions]
        public async Task<IActionResult> Options([FromRoute] Guid clientId)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            Response.Headers.Add("Allow", "GET,PUT,POST,DELETE,OPTIONS,HEAD");
            return Ok();
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> Head([FromRoute] Guid clientId, Guid id)
        {
            if (await _clientRepository.GetClient(clientId) == null) return NotFound();

            if (await _policyRepository.GetPolicy(id) == null) return NotFound();

            return Ok();
        }

        private IActionResult PaginatedResult<T>(PaginationParameters paginationParameters, ICollection<T> values)
        {
            if (!values.Any()) return Ok(new PaginatedValues<T> { Total = values.Count, Values = values });

            if (paginationParameters.Unpaged)
            {
                return Ok(new PaginatedValues<T> { Total = values.Count, Values = values });
            }

            if (paginationParameters.Offset >= values.Count) return BadRequest();

            var offset = values.Skip(paginationParameters.Offset);

            var paginatedValues = paginationParameters.Limit.HasValue
                ? offset.Take(paginationParameters.Limit.Value)
                : offset;

            return Ok(new PaginatedValues<T> { Total = values.Count, Values = paginatedValues });
        }
    }
}
