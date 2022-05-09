namespace TD.CitizenAPI.Application.Catalog.ThoiGianThueNhas;

public class GetThoiGianThueNhaRequest : IRequest<Result<ThoiGianThueNhaDetailsDto>>
{
    public Guid Id { get; set; }

    public GetThoiGianThueNhaRequest(Guid id) => Id = id;
}

public class MucGiaThueNhaByIdSpec : Specification<MucGiaThueNha, ThoiGianThueNhaDetailsDto>, ISingleResultSpecification
{
    public MucGiaThueNhaByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetMucGiaThueNhaRequestHandler : IRequestHandler<GetThoiGianThueNhaRequest, Result<ThoiGianThueNhaDetailsDto>>
{
    private readonly IRepository<MucGiaThueNha> _repository;
    private readonly IStringLocalizer<GetMucGiaThueNhaRequestHandler> _localizer;

    public GetMucGiaThueNhaRequestHandler(IRepository<MucGiaThueNha> repository, IStringLocalizer<GetMucGiaThueNhaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<ThoiGianThueNhaDetailsDto>> Handle(GetThoiGianThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<MucGiaThueNha, ThoiGianThueNhaDetailsDto>)new MucGiaThueNhaByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["MucGiaThueNha.notfound"], request.Id));
        return Result<ThoiGianThueNhaDetailsDto>.Success(item);

    }
}