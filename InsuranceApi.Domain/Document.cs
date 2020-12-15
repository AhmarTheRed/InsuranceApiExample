using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain
{
    public class Document
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string FileName { get; init; }
    }
}
