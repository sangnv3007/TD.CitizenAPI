namespace TD.CitizenAPI.Application.Catalog.Brands;

public class GetBrandRequest : IRequest<Result<BrandDto>>
{
    public Guid Id { get; set; }

    public GetBrandRequest(Guid id) => Id = id;
}

public class BrandByIdSpec : Specification<Brand, BrandDto>, ISingleResultSpecification
{
    public BrandByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetBrandRequestHandler : IRequestHandler<GetBrandRequest, Result<BrandDto>>
{
    private readonly IRepository<Brand> _repository;
    private readonly IStringLocalizer<GetBrandRequestHandler> _localizer;

    public GetBrandRequestHandler(IRepository<Brand> repository, IStringLocalizer<GetBrandRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    /* public async Task<BrandDto> Handle(GetBrandRequest request, CancellationToken cancellationToken) =>
         await _repository.GetBySpecAsync(
             (ISpecification<Brand, BrandDto>)new BrandByIdSpec(request.Id), cancellationToken)
         ?? throw new NotFoundException(string.Format(_localizer["brand.notfound"], request.Id));*/
    public async Task<Result<BrandDto>> Handle(GetBrandRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Brand, BrandDto>)new BrandByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["brand.notfound"], request.Id));
        return Result<BrandDto>.Success(item);

    }
}