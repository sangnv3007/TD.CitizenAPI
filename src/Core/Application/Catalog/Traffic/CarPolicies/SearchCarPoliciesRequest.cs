namespace TD.CitizenAPI.Application.Catalog.CarPolicies;

public class SearchCarPoliciesRequest : PaginationFilter, IRequest<PaginationResponse<CarPolicyDto>>
{
}

public class CarPolicysBySearchRequestSpec : EntitiesByPaginationFilterSpec<CarPolicy, CarPolicyDto>
{
    public CarPolicysBySearchRequestSpec(SearchCarPoliciesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCarPolicysRequestHandler : IRequestHandler<SearchCarPoliciesRequest, PaginationResponse<CarPolicyDto>>
{
    private readonly IReadRepository<CarPolicy> _repository;

    public SearchCarPolicysRequestHandler(IReadRepository<CarPolicy> repository) => _repository = repository;

    public async Task<PaginationResponse<CarPolicyDto>> Handle(SearchCarPoliciesRequest request, CancellationToken cancellationToken)
    {
        var spec = new CarPolicysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CarPolicyDto>(list, count, request.PageNumber, request.PageSize);
    }
}