namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineeringCategories;

public class GetAgriculturalEngineeringCategoryRequest : IRequest<Result<AgriculturalEngineeringCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAgriculturalEngineeringCategoryRequest(Guid id) => Id = id;
}

public class AgriculturalEngineeringCategoryByIdSpec : Specification<AgriculturalEngineeringCategory, AgriculturalEngineeringCategoryDetailsDto>, ISingleResultSpecification
{
    public AgriculturalEngineeringCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAgriculturalEngineeringCategoryRequestHandler : IRequestHandler<GetAgriculturalEngineeringCategoryRequest, Result<AgriculturalEngineeringCategoryDetailsDto>>
{
    private readonly IRepository<AgriculturalEngineeringCategory> _repository;
    private readonly IStringLocalizer<GetAgriculturalEngineeringCategoryRequestHandler> _localizer;

    public GetAgriculturalEngineeringCategoryRequestHandler(IRepository<AgriculturalEngineeringCategory> repository, IStringLocalizer<GetAgriculturalEngineeringCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AgriculturalEngineeringCategoryDetailsDto>> Handle(GetAgriculturalEngineeringCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AgriculturalEngineeringCategory, AgriculturalEngineeringCategoryDetailsDto>)new AgriculturalEngineeringCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AgriculturalEngineeringCategory.notfound"], request.Id));
        return Result<AgriculturalEngineeringCategoryDetailsDto>.Success(item);

    }
}