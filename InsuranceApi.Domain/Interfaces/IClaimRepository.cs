using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IClaimRepository
    {
        public Task<IEnumerable<Claim>> GetClaims(Guid policyId);
    }
}
