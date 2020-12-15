using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.FakeOperations
{
    public class FakePolicyRepository : IPolicyRepository
    {
        public async Task<Policy> AddPolicy(Guid clientId, Policy policy)
        {
            policy.Id = Guid.NewGuid();
            return policy;
        }

        public async Task DeletePolicy(Guid Id)
        {
            //beep boop updated
        }

        public async Task<IEnumerable<Policy>> GetPolicies(Guid clientId)
        {
            return new List<Policy>
            {
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Cyber"
                },
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Employee Public Liability"
                },
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Cyber"
                },
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Motor"
                }
            };
        }

        public async Task<Policy> GetPolicy(Guid Id)
        {
            return new Policy
            {
                Id = Guid.NewGuid(),
                Type = "Cyber"
            };
        }

        public async Task UpdatePolicy(Policy policy)
        {
            //beep boop updated
        }
    }
}
