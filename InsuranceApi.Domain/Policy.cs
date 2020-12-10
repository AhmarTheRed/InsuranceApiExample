using System;

namespace InsuranceApi.Domain
{
    public class Policy
    {
        public Guid Reference { get; init; }

        public string Type { get; init; }
    }
}
