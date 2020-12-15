using System.Collections.Generic;

namespace InsuranceApi.Domain
{
    public class PaginatedValues<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Values { get; set; }
    }
}