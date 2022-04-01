namespace TD.CitizenAPI.Application.Catalog.AlertInformations;

public class GetAlertInformationRequest : IRequest<Result<AlertInformationDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAlertInformationRequest(Guid id) => Id = id;
}

public class AlertInformationByIdSpec : Specification<AlertInformation, AlertInformationDetailsDto>, ISingleResultSpecification
{
    public AlertInformationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.AlertOrganization)
        .Include(p => p.AlertCategory)
        ;
}

public class GetAlertInformationRequestHandler : IRequestHandler<GetAlertInformationRequest, Result<AlertInformationDetailsDto>>
{
    private readonly IRepository<AlertInformation> _repository;
    private readonly IStringLocalizer<GetAlertInformationRequestHandler> _localizer;

    public GetAlertInformationRequestHandler(IRepository<AlertInformation> repository, IStringLocalizer<GetAlertInformationRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AlertInformationDetailsDto>> Handle(GetAlertInformationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AlertInformation, AlertInformationDetailsDto>)new AlertInformationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AlertInformation.notfound"], request.Id));
        return Result<AlertInformationDetailsDto>.Success(item);

    }
}