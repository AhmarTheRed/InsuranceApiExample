using InsuranceApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.FakeOperations
{
    public class FakePolicyRepository : IPolicyRepository
    {
        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            return new List<Policy>
            {
                new Policy
                {
                    Reference = Guid.NewGuid(),
                    Type = "Cyber"
                },
                new Policy
                {
                    Reference = Guid.NewGuid(),
                    Type = "Employee Public Liability"
                },
                new Policy
                {
                    Reference = Guid.NewGuid(),
                    Type = "Cyber"
                },
                new Policy
                {
                    Reference = Guid.NewGuid(),
                    Type = "Motor"
                }
            };
        }
    }
}
