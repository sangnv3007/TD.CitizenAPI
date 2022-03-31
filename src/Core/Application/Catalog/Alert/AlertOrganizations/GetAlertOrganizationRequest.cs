namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public class GetAlertOrganizationRequest : IRequest<Result<AlertOrganizationDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAlertOrganizationRequest(Guid id) => Id = id;
}

public class AlertOrganizationByIdSpec : Specification<AlertOrganization, AlertOrganizationDetailsDto>, ISingleResultSpecification
{
    public AlertOrganizationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAlertOrganizationRequestHandler : IRequestHandler<GetAlertOrganizationRequest, Result<AlertOrganizationDetailsDto>>
{
    private readonly IRepository<AlertOrganization> _repository;
    private readonly IStringLocalizer<GetAlertOrganizationRequestHandler> _localizer;

    public GetAlertOrganizationRequestHandler(IRepository<AlertOrganization> repository, IStringLocalizer<GetAlertOrganizationRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AlertOrganizationDetailsDto>> Handle(GetAlertOrganizationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AlertOrganization, AlertOrganizationDetailsDto>)new AlertOrganizationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AlertOrganization.notfound"], request.Id));
        return Result<AlertOrganizationDetailsDto>.Success(item);

    }
}