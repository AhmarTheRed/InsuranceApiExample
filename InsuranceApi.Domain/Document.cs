using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
    }
}
