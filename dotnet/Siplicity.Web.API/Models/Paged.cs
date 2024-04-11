namespace Siplicity.Web.API.Models
{
    public class Paged<T>
    {
        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount {  get; }

        public int TotalPages { get; }

        public List<T> PagedItems { get; }

        public Paged(List<T> data, int page, int pageSize, int totalCount)
        {
            PageIndex = page;
            PageSize = pageSize;
            PagedItems = data;

            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
        }

        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
