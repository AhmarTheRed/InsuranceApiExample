using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InsuranceApi.Domain.Interfaces;
using InsuranceApi.Domain;
using InsuranceApi.WebApi.DTOs;

namespace InsuranceApi.WebApi.Controllers
{
    [Route("api/clients")]
    [ApiController]
    
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientRepository _clientRepository;

        public ClientsController(ILogger<ClientsController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ClientQueryFilters filters = null)
        {
            filters ??= new ClientQueryFilters();

            return !string.IsNullOrEmpty(filters.Name)
                ? Ok(await _clientRepository.GetClientsByName(filters.Name))
                : Ok(await _clientRepository.GetClients(filters.q));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var client = await _clientRepository.GetClient(id);

            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Client client)
        {
            if (await _clientRepository.GetClient(id) == null) return NotFound();

            await _clientRepository.UpdateClient(client);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            var addedClient = await _clientRepository.AddClient(client);
            return CreatedAtAction(nameof(Get), new { id = addedClient.Id }, addedClient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _clientRepository.GetClient(id) == null) return NotFound();

            await _clientRepository.DeleteClient(id);
            return NoContent();
        }

        [HttpOptions]
        public async Task<IActionResult> Options()
        {
            Response.Headers.Add("Allow", "GET,PUT,POST,DELETE,OPTIONS,HEAD");
            return Ok();
        }

        [HttpHead("{id}")]
        public async Task<IActionResult> Head(Guid id)
        {
            if (await _clientRepository.GetClient(id) == null) return NotFound();

            return Ok();
        }
    }
}
