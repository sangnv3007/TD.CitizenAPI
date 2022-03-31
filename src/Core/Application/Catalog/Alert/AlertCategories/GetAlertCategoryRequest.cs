namespace TD.CitizenAPI.Application.Catalog.AlertCategories;

public class GetAlertCategoryRequest : IRequest<Result<AlertCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAlertCategoryRequest(Guid id) => Id = id;
}

public class AlertCategoryByIdSpec : Specification<AlertCategory, AlertCategoryDetailsDto>, ISingleResultSpecification
{
    public AlertCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAlertCategoryRequestHandler : IRequestHandler<GetAlertCategoryRequest, Result<AlertCategoryDetailsDto>>
{
    private readonly IRepository<AlertCategory> _repository;
    private readonly IStringLocalizer<GetAlertCategoryRequestHandler> _localizer;

    public GetAlertCategoryRequestHandler(IRepository<AlertCategory> repository, IStringLocalizer<GetAlertCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AlertCategoryDetailsDto>> Handle(GetAlertCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AlertCategory, AlertCategoryDetailsDto>)new AlertCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AlertCategory.notfound"], request.Id));
        return Result<AlertCategoryDetailsDto>.Success(item);

    }
}