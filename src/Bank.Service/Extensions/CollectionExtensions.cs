using Bank.Domain.Configuration;

namespace Bank.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            if (@params.PageIndex < 1)
            {
                @params.PageIndex = 1;
            }

            return source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
        }
    }
}
