using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IDocumentRepository
    {
        public Task<IEnumerable<Document>> GetDocumentsForPolicy(Guid policyId);
        public Task<IEnumerable<Document>> GetDocumentsForClaim(Guid claimId);
        public Task<Document> GetDocument(Guid id);
        public Task UpdateDocument(Document claim);
        public Task<Document> AddDocumentToPolicy(Guid policyId, Document claim);
        public Task<Document> AddDocumentToClaim(Guid claimId, Document claim);
        public Task DeleteDocument(Guid id);
    }
}
