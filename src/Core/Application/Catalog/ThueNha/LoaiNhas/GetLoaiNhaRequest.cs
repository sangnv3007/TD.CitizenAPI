namespace TD.CitizenAPI.Application.Catalog.LoaiNhas;

public class GetLoaiNhaRequest : IRequest<Result<LoaiNhaDetailsDto>>
{
    public Guid Id { get; set; }

    public GetLoaiNhaRequest(Guid id) => Id = id;
}

public class LoaiNhaByIdSpec : Specification<LoaiNha, LoaiNhaDetailsDto>, ISingleResultSpecification
{
    public LoaiNhaByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetLoaiNhaRequestHandler : IRequestHandler<GetLoaiNhaRequest, Result<LoaiNhaDetailsDto>>
{
    private readonly IRepository<LoaiNha> _repository;
    private readonly IStringLocalizer<GetLoaiNhaRequestHandler> _localizer;

    public GetLoaiNhaRequestHandler(IRepository<LoaiNha> repository, IStringLocalizer<GetLoaiNhaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<LoaiNhaDetailsDto>> Handle(GetLoaiNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<LoaiNha, LoaiNhaDetailsDto>)new LoaiNhaByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["LoaiNha.notfound"], request.Id));
        return Result<LoaiNhaDetailsDto>.Success(item);

    }
}