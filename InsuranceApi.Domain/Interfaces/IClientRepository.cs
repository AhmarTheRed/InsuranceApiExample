using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClients(string searchText = null);
        public Task<Client> GetClient(Guid id);
        public Task UpdateClient(Client client);
        public Task<Client> AddClient(Client client);
        public Task DeleteClient(Guid id);
        public Task<IEnumerable<Client>> GetClientsByName(string name);
    }
}
