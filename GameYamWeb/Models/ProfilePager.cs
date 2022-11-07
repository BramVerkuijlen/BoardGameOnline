namespace GameYamWeb.Models
{
    public class ProfilePager
    {
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        private readonly int pageRange = 5;

        public ProfilePager()
        {

        }
        public ProfilePager(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentpage = page;

            StartPage = currentpage - pageRange;
            EndPage = currentpage + pageRange-1;

            if (StartPage < 0)
            {

            }
        }
    }
}
