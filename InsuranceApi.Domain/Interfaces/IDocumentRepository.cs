using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        public Task<IEnumerable<Document>> GetDocumentsForPolicy(Guid policyId);
        public Task<IEnumerable<Document>> GetDocumentsForClaim(Guid claimId);
    }
}
