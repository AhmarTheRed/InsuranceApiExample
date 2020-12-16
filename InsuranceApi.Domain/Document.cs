using System;

namespace InsuranceApi.Domain
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
    }
}