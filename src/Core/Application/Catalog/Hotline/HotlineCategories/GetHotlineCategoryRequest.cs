namespace TD.CitizenAPI.Application.Catalog.HotlineCategories;

public class GetHotlineCategoryRequest : IRequest<Result<HotlineCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetHotlineCategoryRequest(Guid id) => Id = id;
}

public class HotlineCategoryByIdSpec : Specification<HotlineCategory, HotlineCategoryDetailsDto>, ISingleResultSpecification
{
    public HotlineCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetHotlineCategoryRequestHandler : IRequestHandler<GetHotlineCategoryRequest, Result<HotlineCategoryDetailsDto>>
{
    private readonly IRepository<HotlineCategory> _repository;
    private readonly IStringLocalizer<GetHotlineCategoryRequestHandler> _localizer;

    public GetHotlineCategoryRequestHandler(IRepository<HotlineCategory> repository, IStringLocalizer<GetHotlineCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<HotlineCategoryDetailsDto>> Handle(GetHotlineCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<HotlineCategory, HotlineCategoryDetailsDto>)new HotlineCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["hotlinecategory.notfound"], request.Id));
        return Result<HotlineCategoryDetailsDto>.Success(item);

    }
}