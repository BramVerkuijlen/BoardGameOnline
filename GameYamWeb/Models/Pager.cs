namespace GameYamWeb.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        private readonly int PageRange = 5;

        public Pager()
        {

        }
        public Pager(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentpage = page;

            int startPage = currentpage - PageRange;
            int endPage = currentpage + PageRange-1;

            if (startPage < 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > (PageRange*2))
                {
                    startPage = endPage - ((PageRange*2)-1);
                }
            }

            TotalItems = totalItems;
            TotalPages = totalPages;
            PageSize = pageSize;
            CurrentPage = startPage;
            StartPage = startPage;
            EndPage = endPage;

        }
    }
}
