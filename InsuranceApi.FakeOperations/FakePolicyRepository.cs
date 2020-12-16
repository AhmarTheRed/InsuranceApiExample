using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceApi.Domain;
using InsuranceApi.Domain.Interfaces;

namespace InsuranceApi.FakeOperations
{
    public class FakePolicyRepository : IPolicyRepository
    {
        public async Task<Policy> AddPolicy(Guid clientId, Policy policy)
        {
            policy.Id = Guid.NewGuid();
            return policy;
        }

        public async Task DeletePolicy(Guid Id)
        {
            //beep boop updated
        }

        public async Task<PaginatedValues<Policy>> GetPolicies(Guid clientId, PaginationParameters pagination = null)
        {
            pagination ??= new PaginationParameters
            {
                Unpaged = true
            };

            var policies = new List<Policy>
            {
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Cyber"
                },
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Employee Public Liability"
                },
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Cyber"
                },
                new Policy
                {
                    Id = Guid.NewGuid(),
                    Type = "Motor"
                }
            };
            return PaginatedResult(pagination, policies);
        }

        public async Task<Policy> GetPolicy(Guid Id)
        {
            return new Policy
            {
                Id = Guid.NewGuid(),
                Type = "Cyber"
            };
        }

        public async Task UpdatePolicy(Policy policy)
        {
            //beep boop updated
        }


        protected PaginatedValues<Policy> PaginatedResult(PaginationParameters paginationParameters,
            ICollection<Policy> values)
        {
            if (!values.Any()) return new PaginatedValues<Policy> {Total = values.Count, Values = values};

            if (paginationParameters.Unpaged)
                return new PaginatedValues<Policy> {Total = values.Count, Values = values};

            var offset = values.Skip(paginationParameters.Offset);

            var paginatedValues = paginationParameters.Limit.HasValue
                ? offset.Take(paginationParameters.Limit.Value)
                : offset;

            return new PaginatedValues<Policy> {Total = values.Count, Values = paginatedValues};
        }
    }
}