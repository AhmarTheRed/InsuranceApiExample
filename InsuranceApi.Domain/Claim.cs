using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain
{
    public class Claim
    {
        public Guid Id { get; init; }
        public DateTime DateTime { get; init; }
        public decimal Amount { get; init; }
        public string Details { get; init; }
    }
}
