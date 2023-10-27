namespace ChatApp.Common.DTO.Page
{
    public class PagePaginationDto
    {
        public int PageNumber { get; set; } = 1;

        const int maxPageSize = 50;
        private int _pageSize = 30;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > maxPageSize ? maxPageSize : value; }
        }

    }
}
