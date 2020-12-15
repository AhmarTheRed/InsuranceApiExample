using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.FakeOperations
{
    public class FakeDocumentRepository : IDocumentRepository
    {
        public async Task<IEnumerable<Document>> GetDocumentsForClaim(Guid claimId)
        {
            return new List<Document>
            {
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Notes on claim",
                    FileName = "Notes-on-claim.docx"
                },
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Invoices",
                    FileName = "invoices.docx"
                },
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Picture of damage",
                    FileName = "damage.jpg"
                }
            };
        }

        public async Task<IEnumerable<Document>> GetDocumentsForPolicy(Guid policyId)
        {
            return new List<Document>
            {
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Policy Certificate",
                    FileName = "policy.pdf"
                },
                new Document
                {
                    Id = Guid.NewGuid(),
                    Title = "Terms and conditions",
                    FileName = "TsandCs.pdf"
                }
            };
        }
    }
}
