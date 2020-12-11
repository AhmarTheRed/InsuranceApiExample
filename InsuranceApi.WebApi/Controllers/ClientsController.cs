using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InsuranceApi.Domain.Interfaces;
using InsuranceApi.Domain;

namespace InsuranceApi.WebApi.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientRepository.GetClients();
        }
    }
}
