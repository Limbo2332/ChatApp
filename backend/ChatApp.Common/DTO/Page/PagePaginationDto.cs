namespace ChatApp.Common.DTO.Page
{
    public class PagePaginationDto
    {
        public int PageNumber { get; set; } = 1;

        const int maxPageSize = 100;
        private int _pageSize = 30;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }
    }
}
