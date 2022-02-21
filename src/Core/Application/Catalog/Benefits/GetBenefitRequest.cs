namespace TD.CitizenAPI.Application.Catalog.Benefits;

public class GetBenefitRequest : IRequest<Result<BenefitDetailsDto>>
{
    public Guid Id { get; set; }

    public GetBenefitRequest(Guid id) => Id = id;
}

public class BenefitByIdSpec : Specification<Benefit, BenefitDetailsDto>, ISingleResultSpecification
{
    public BenefitByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetBenefitRequestHandler : IRequestHandler<GetBenefitRequest, Result<BenefitDetailsDto>>
{
    private readonly IRepository<Benefit> _repository;
    private readonly IStringLocalizer<GetBenefitRequestHandler> _localizer;

    public GetBenefitRequestHandler(IRepository<Benefit> repository, IStringLocalizer<GetBenefitRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<BenefitDetailsDto>> Handle(GetBenefitRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Benefit, BenefitDetailsDto>)new BenefitByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["benefit.notfound"], request.Id));
        return Result<BenefitDetailsDto>.Success(item);

    }
}