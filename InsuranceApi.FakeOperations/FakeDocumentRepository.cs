using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.FakeOperations
{
    public class FakeDocumentRepository : IDocumentRepository
    {
        public async Task<Document> AddDocumentToClaim(Guid claimId, Document document)
        {
            document.Id = Guid.NewGuid();
            return document;
        }

        public async Task<Document> AddDocumentToPolicy(Guid policyId, Document document)
        {
            document.Id = Guid.NewGuid();
            return document;
        }

        public async Task DeleteDocument(Guid Id)
        {
            //beep boop deleted
        }

        public async Task<Document> GetDocument(Guid Id)
        {
            new Document
            {
                Id = Id,
                Title = "Policy Certificate",
                FileName = "policy.pdf"
            };
        }

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

        public async Task UpdateDocument(Document claim)
        {
            //beep boop updated
        }
    }
}
