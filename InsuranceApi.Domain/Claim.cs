using System;

namespace InsuranceApi.Domain
{
    public class Claim
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
    }
}