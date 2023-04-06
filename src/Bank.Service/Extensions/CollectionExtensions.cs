using Bank.Domain.Configuration;

namespace Bank.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            int numberOfItemsToSkip = (@params.PageIndex - 1) * @params.PageSize;
            int totalCount = source.Count();

            if (numberOfItemsToSkip >= totalCount)
            {
                int toTake = totalCount % @params.PageSize;

                return source.TakeLast(toTake);
            }

            return source.Skip(numberOfItemsToSkip).Take(@params.PageSize);
        }
    }
}
