using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InsuranceApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {

        private readonly ILogger<PoliciesController> _logger;
        private readonly IPolicyRepository _policyRepository;

        public PoliciesController(ILogger<PoliciesController> logger, IPolicyRepository policyRepository)
        {
            _logger = logger;
            _policyRepository = policyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_policyRepository.GetPolicies());
        }
    }
}
