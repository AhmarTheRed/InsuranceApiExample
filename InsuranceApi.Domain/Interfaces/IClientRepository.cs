using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClients();
        public Task<Client> GetClient(Guid Id);
        public Task UpdateClient(Client client);
        public Task<Client> AddClient(Client client);
        public Task DeleteClient(Guid Id);
    }
}
