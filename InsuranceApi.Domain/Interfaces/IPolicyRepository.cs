using System;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IPolicyRepository
    {
        public Task<PaginatedValues<Policy>> GetPolicies(Guid clientId, PaginationParameters pagination = null);
        public Task<Policy> GetPolicy(Guid id);
        public Task UpdatePolicy(Policy policy);
        public Task<Policy> AddPolicy(Guid clientId, Policy policy);
        public Task DeletePolicy(Guid id);
    }
}