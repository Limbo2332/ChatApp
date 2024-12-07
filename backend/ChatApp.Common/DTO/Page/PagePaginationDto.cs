namespace ChatApp.Common.DTO.Page
{
    public class PagePaginationDto
    {
        public int PageNumber { get; set; } = 1;

        private const int MAX_PAGE_SIZE = 100;
        private int _pageSize = 30;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
        }
    }
}
