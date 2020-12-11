using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;

namespace InsuranceApi.FakeOperations
{
    public class FakeClientRepository : IClientRepository
    {
        public async Task<IEnumerable<Client>> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Reference = Guid.NewGuid(),
                    Name = "International Rescue"
                },
                new Client
                {
                    Reference = Guid.NewGuid(),
                    Name = "EFSF"
                },
                new Client
                {
                    Reference = Guid.NewGuid(),
                    Name = "Acme Inc"
                }
            };
        }
    }
}
