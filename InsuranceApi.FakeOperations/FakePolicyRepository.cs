using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.FakeOperations
{
    public class FakePolicyRepository : IPolicyRepository
    {
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
    }
}
