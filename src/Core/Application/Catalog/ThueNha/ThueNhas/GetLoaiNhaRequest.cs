namespace TD.CitizenAPI.Application.Catalog.ThueNhas;

public class GetThueNhaRequest : IRequest<Result<ThueNhaDetailsDto>>
{
    public Guid Id { get; set; }

    public GetThueNhaRequest(Guid id) => Id = id;
}

public class ThueNhaByIdSpec : Specification<ThueNha, ThueNhaDetailsDto>, ISingleResultSpecification
{
    public ThueNhaByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetThueNhaRequestHandler : IRequestHandler<GetThueNhaRequest, Result<ThueNhaDetailsDto>>
{
    private readonly IRepository<ThueNha> _repository;
    private readonly IStringLocalizer<GetThueNhaRequestHandler> _localizer;

    public GetThueNhaRequestHandler(IRepository<ThueNha> repository, IStringLocalizer<GetThueNhaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<ThueNhaDetailsDto>> Handle(GetThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<ThueNha, ThueNhaDetailsDto>)new ThueNhaByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["ThueNha.notfound"], request.Id));
        return Result<ThueNhaDetailsDto>.Success(item);

    }
}