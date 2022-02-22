namespace TD.CitizenAPI.Application.Catalog.Industries;

public class GetIndustryRequest : IRequest<Result<IndustryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetIndustryRequest(Guid id) => Id = id;
}

public class IndustryByIdSpec : Specification<Industry, IndustryDetailsDto>, ISingleResultSpecification
{
    public IndustryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetIndustryRequestHandler : IRequestHandler<GetIndustryRequest, Result<IndustryDetailsDto>>
{
    private readonly IRepository<Industry> _repository;
    private readonly IStringLocalizer<GetIndustryRequestHandler> _localizer;

    public GetIndustryRequestHandler(IRepository<Industry> repository, IStringLocalizer<GetIndustryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<IndustryDetailsDto>> Handle(GetIndustryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Industry, IndustryDetailsDto>)new IndustryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Industry.notfound"], request.Id));
        return Result<IndustryDetailsDto>.Success(item);

    }
}