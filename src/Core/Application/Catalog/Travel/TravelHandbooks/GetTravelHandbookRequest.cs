namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public class GetTravelHandbookRequest : IRequest<Result<TravelHandbookDetailsDto>>
{
    public Guid Id { get; set; }

    public GetTravelHandbookRequest(Guid id) => Id = id;
}

public class TravelHandbookByIdSpec : Specification<TravelHandbook, TravelHandbookDetailsDto>, ISingleResultSpecification
{
    public TravelHandbookByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetTravelHandbookRequestHandler : IRequestHandler<GetTravelHandbookRequest, Result<TravelHandbookDetailsDto>>
{
    private readonly IRepository<TravelHandbook> _repository;
    private readonly IStringLocalizer<GetTravelHandbookRequestHandler> _localizer;

    public GetTravelHandbookRequestHandler(IRepository<TravelHandbook> repository, IStringLocalizer<GetTravelHandbookRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<TravelHandbookDetailsDto>> Handle(GetTravelHandbookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<TravelHandbook, TravelHandbookDetailsDto>)new TravelHandbookByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["TravelHandbook.notfound"], request.Id));
        return Result<TravelHandbookDetailsDto>.Success(item);

    }
}