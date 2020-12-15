using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
