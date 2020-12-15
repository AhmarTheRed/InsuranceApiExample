using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;

namespace InsuranceApi.FakeOperations
{
    public class FakeClientRepository : IClientRepository
    {
        public async Task<Client> AddClient(Client client)
        {
            client.Id = Guid.NewGuid();
            return client;
        }

        public async Task DeleteClient(Guid id)
        {
            // beep boop deleted
        }

        public async Task<IEnumerable<Client>> GetClientsByName(string name)
        {
            return new List<Client>
            {
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = $"{name} Inc"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = $"{name} International"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = $"Company {name}"
                }
            };
        }

        public async Task<Client> GetClient(Guid id)
        {
            return new Client
            {
                Id = Guid.NewGuid(),
                Name = "International Rescue"
            };
        }

        public async Task<IEnumerable<Client>> GetClients(string searchText = null)
        {
            //search text can be used to filter the clients list here

            return new List<Client>
            {
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "International Rescue"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "EFSF"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    Name = "Acme Inc"
                }
            };
        }

        public async Task UpdateClient(Client client)
        {
            // beep boop updated
        }
    }
}
