namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumCategories;

public class GetEnterpriseForumCategoryRequest : IRequest<Result<EnterpriseForumCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetEnterpriseForumCategoryRequest(Guid id) => Id = id;
}

public class EnterpriseForumCategoryByIdSpec : Specification<EnterpriseForumCategory, EnterpriseForumCategoryDetailsDto>, ISingleResultSpecification
{
    public EnterpriseForumCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetEnterpriseForumCategoryRequestHandler : IRequestHandler<GetEnterpriseForumCategoryRequest, Result<EnterpriseForumCategoryDetailsDto>>
{
    private readonly IRepository<EnterpriseForumCategory> _repository;
    private readonly IStringLocalizer<GetEnterpriseForumCategoryRequestHandler> _localizer;

    public GetEnterpriseForumCategoryRequestHandler(IRepository<EnterpriseForumCategory> repository, IStringLocalizer<GetEnterpriseForumCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<EnterpriseForumCategoryDetailsDto>> Handle(GetEnterpriseForumCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EnterpriseForumCategory, EnterpriseForumCategoryDetailsDto>)new EnterpriseForumCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumCategory.notfound"], request.Id));
        return Result<EnterpriseForumCategoryDetailsDto>.Success(item);

    }
}