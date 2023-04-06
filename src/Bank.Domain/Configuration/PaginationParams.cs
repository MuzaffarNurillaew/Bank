namespace Bank.Domain.Configuration
{
    public class PaginationParams
    {
        private const short _maxSize = 10;
        private short _pageSize;

        public short PageSize 
        {
            get
            { 
                return _pageSize;
            }
            set 
            { 
                _pageSize = value <= _maxSize ? value : _maxSize;
            }
        }

        public int PageIndex { get; set; }
    }
}
