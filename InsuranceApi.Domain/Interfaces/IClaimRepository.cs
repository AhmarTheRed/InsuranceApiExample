using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IClaimRepository
    {
        public Task<IEnumerable<Claim>> GetClaims(Guid policyId);
        public Task<Claim> GetClaim(Guid Id);
        public Task UpdateClaim(Claim claim);
        public Task<Claim> AddClaim(Guid policyId, Claim claim);
        public Task DeleteClaim(Guid Id);
    }
}
