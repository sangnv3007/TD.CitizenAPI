namespace TD.CitizenAPI.Application.Catalog.Categories;

public class GetCategoryRequest : IRequest<Result<CategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetCategoryRequest(Guid id) => Id = id;
}

public class CategoryByIdSpec : Specification<Category, CategoryDetailsDto>, ISingleResultSpecification
{
    public CategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, Result<CategoryDetailsDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IStringLocalizer<GetCategoryRequestHandler> _localizer;

    public GetCategoryRequestHandler(IRepository<Category> repository, IStringLocalizer<GetCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<CategoryDetailsDto>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Category, CategoryDetailsDto>)new CategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["category.notfound"], request.Id));
        return Result<CategoryDetailsDto>.Success(item);

    }
}