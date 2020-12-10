using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain
{
    public interface IPolicyRepository
    {
        public Task<IEnumerable<Policy>> GetPolicies();
    }
}
