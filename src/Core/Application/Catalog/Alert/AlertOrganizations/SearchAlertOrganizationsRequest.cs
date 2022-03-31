namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public class SearchAlertOrganizationsRequest : PaginationFilter, IRequest<PaginationResponse<AlertOrganizationDto>>
{
}

public class AlertOrganizationsBySearchRequestSpec : EntitiesByPaginationFilterSpec<AlertOrganization, AlertOrganizationDto>
{
    public AlertOrganizationsBySearchRequestSpec(SearchAlertOrganizationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchAlertOrganizationsRequestHandler : IRequestHandler<SearchAlertOrganizationsRequest, PaginationResponse<AlertOrganizationDto>>
{
    private readonly IReadRepository<AlertOrganization> _repository;

    public SearchAlertOrganizationsRequestHandler(IReadRepository<AlertOrganization> repository) => _repository = repository;

    public async Task<PaginationResponse<AlertOrganizationDto>> Handle(SearchAlertOrganizationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertOrganizationsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AlertOrganizationDto>(list, count, request.PageNumber, request.PageSize);
    }
}