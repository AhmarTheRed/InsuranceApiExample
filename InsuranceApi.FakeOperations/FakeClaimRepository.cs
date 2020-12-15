using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.FakeOperations
{
    public class FakeClaimRepository : IClaimRepository
    {
        public async Task<IEnumerable<Claim>> GetClaims(Guid policyId)
        {
            return new List<Claim>
            {
                new Claim
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Today,
                    Amount = 100000m,
                    Details = "Loss of inventory due to flooding"
                },
                new Claim
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Today.AddMonths(-3),
                    Amount = 45000m,
                    Details = "Loss of business due to pandemic"
                }
            };
        }
    }
}
