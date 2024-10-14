namespace ShopAppApi.Data
{
    public class BaseRequest
    {
        public int page { get; set; } = 1;
        public int pageSize { get => _pageSize; set => _pageSize = _maxPageSize < value ? _maxPageSize : value; }
        public string? search { get; set; } = null!;

        private int _pageSize = 30;
        private const int _maxPageSize = 300;
    }
}
