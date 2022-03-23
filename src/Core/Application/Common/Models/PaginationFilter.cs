namespace TD.CitizenAPI.Application.Common.Models;

public class PaginationFilter : BaseFilter
{
    public int PageNumber { get; set; }

    //public int PageSize { get; set; } = int.MaxValue;
    public int PageSize { get; set; } = 100;

    public string[]? OrderBy { get; set; }
}

public static class PaginationFilterExtensions
{
    public static bool HasOrderBy(this PaginationFilter filter) =>
        filter.OrderBy?.Any() is true;
}