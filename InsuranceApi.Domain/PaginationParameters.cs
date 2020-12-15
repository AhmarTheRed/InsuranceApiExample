namespace InsuranceApi.Domain
{
    public class PaginationParameters
    {
        public int? Limit { get; set; }
        public int Offset { get; set; } = 0;
        public bool Unpaged { get; set; } = false;
    }
}