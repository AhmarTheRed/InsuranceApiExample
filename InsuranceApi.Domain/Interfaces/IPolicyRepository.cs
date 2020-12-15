using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IPolicyRepository
    {
        public Task<IEnumerable<Policy>> GetPolicies(Guid clientId);
        public Task<Policy> GetPolicy(Guid Id);
        public Task UpdatePolicy(Policy policy);
        public Task<Policy> AddPolicy(Guid clientId, Policy policy);
        public Task DeletePolicy(Guid Id);
    }
}
