namespace ShopAppApi.Request
{
    public class BaseRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get => _pageSize; set => _pageSize = _maxPageSize < value ? _maxPageSize : value; }
        public string? Search { get; set; } = null!;

        private int _pageSize = 30;
        private const int _maxPageSize = 300;
    }
}
