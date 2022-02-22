namespace TD.CitizenAPI.Application.Catalog.Salaries;

public class SearchSalariesRequest : PaginationFilter, IRequest<PaginationResponse<SalaryDto>>
{
}

public class SalarysBySearchRequestSpec : EntitiesByPaginationFilterSpec<Salary, SalaryDto>
{
    public SalarysBySearchRequestSpec(SearchSalariesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchSalarysRequestHandler : IRequestHandler<SearchSalariesRequest, PaginationResponse<SalaryDto>>
{
    private readonly IReadRepository<Salary> _repository;

    public SearchSalarysRequestHandler(IReadRepository<Salary> repository) => _repository = repository;

    public async Task<PaginationResponse<SalaryDto>> Handle(SearchSalariesRequest request, CancellationToken cancellationToken)
    {
        var spec = new SalarysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<SalaryDto>(list, count, request.PageNumber, request.PageSize);
    }
}