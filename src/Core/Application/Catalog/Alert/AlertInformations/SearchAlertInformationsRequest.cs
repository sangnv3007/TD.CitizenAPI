namespace TD.CitizenAPI.Application.Catalog.AlertInformations;

public class SearchAlertInformationsRequest : PaginationFilter, IRequest<PaginationResponse<AlertInformationDto>>
{
    public Guid? AlertCategoryId { get; set; }
    public Guid? AlertOrganizationId { get; set; }
}

public class AlertInformationsBySearchRequestSpec : EntitiesByPaginationFilterSpec<AlertInformation, AlertInformationDto>
{
    public AlertInformationsBySearchRequestSpec(SearchAlertInformationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy())
                .Where(p => p.AlertCategoryId.Equals(request.AlertCategoryId!.Value), request.AlertCategoryId.HasValue)

                .Where(p => p.AlertOrganizationId.Equals(request.AlertOrganizationId!.Value), request.AlertOrganizationId.HasValue)

        ;
}

public class SearchAlertInformationsRequestHandler : IRequestHandler<SearchAlertInformationsRequest, PaginationResponse<AlertInformationDto>>
{
    private readonly IReadRepository<AlertInformation> _repository;

    public SearchAlertInformationsRequestHandler(IReadRepository<AlertInformation> repository) => _repository = repository;

    public async Task<PaginationResponse<AlertInformationDto>> Handle(SearchAlertInformationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertInformationsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AlertInformationDto>(list, count, request.PageNumber, request.PageSize);
    }
}