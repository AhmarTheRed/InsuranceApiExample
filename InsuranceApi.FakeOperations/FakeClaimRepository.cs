using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;

namespace InsuranceApi.FakeOperations
{
    public class FakeClaimRepository : IClaimRepository
    {
        public async Task<Claim> AddClaim(Guid policyId, Claim claim)
        {
            claim.Id = Guid.NewGuid();
            return claim;
        }

        public async Task DeleteClaim(Guid Id)
        {
            //beep boop deleted
        }

        public async Task<Claim> GetClaim(Guid Id)
        {
            return new Claim
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Today.AddMonths(-3),
                Amount = 45000m,
                Details = "Loss of business due to pandemic"
            };
        }

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

        public async Task UpdateClaim(Claim claim)
        {
            //beep boop updated
        }
    }
}