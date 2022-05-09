namespace TD.CitizenAPI.Application.Catalog.DienTichNhas;

public class GetDienTichNhaRequest : IRequest<Result<DienTichNhaDetailsDto>>
{
    public Guid Id { get; set; }

    public GetDienTichNhaRequest(Guid id) => Id = id;
}

public class DienTichNhaByIdSpec : Specification<DienTichNha, DienTichNhaDetailsDto>, ISingleResultSpecification
{
    public DienTichNhaByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetDienTichNhaRequestHandler : IRequestHandler<GetDienTichNhaRequest, Result<DienTichNhaDetailsDto>>
{
    private readonly IRepository<DienTichNha> _repository;
    private readonly IStringLocalizer<GetDienTichNhaRequestHandler> _localizer;

    public GetDienTichNhaRequestHandler(IRepository<DienTichNha> repository, IStringLocalizer<GetDienTichNhaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<DienTichNhaDetailsDto>> Handle(GetDienTichNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<DienTichNha, DienTichNhaDetailsDto>)new DienTichNhaByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["DienTichNha.notfound"], request.Id));
        return Result<DienTichNhaDetailsDto>.Success(item);

    }
}