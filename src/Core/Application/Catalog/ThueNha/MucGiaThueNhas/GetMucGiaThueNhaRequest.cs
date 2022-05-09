namespace TD.CitizenAPI.Application.Catalog.MucGiaThueNhas;

public class GetMucGiaThueNhaRequest : IRequest<Result<MucGiaThueNhaDetailsDto>>
{
    public Guid Id { get; set; }

    public GetMucGiaThueNhaRequest(Guid id) => Id = id;
}

public class MucGiaThueNhaByIdSpec : Specification<MucGiaThueNha, MucGiaThueNhaDetailsDto>, ISingleResultSpecification
{
    public MucGiaThueNhaByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetMucGiaThueNhaRequestHandler : IRequestHandler<GetMucGiaThueNhaRequest, Result<MucGiaThueNhaDetailsDto>>
{
    private readonly IRepository<MucGiaThueNha> _repository;
    private readonly IStringLocalizer<GetMucGiaThueNhaRequestHandler> _localizer;

    public GetMucGiaThueNhaRequestHandler(IRepository<MucGiaThueNha> repository, IStringLocalizer<GetMucGiaThueNhaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<MucGiaThueNhaDetailsDto>> Handle(GetMucGiaThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<MucGiaThueNha, MucGiaThueNhaDetailsDto>)new MucGiaThueNhaByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["MucGiaThueNha.notfound"], request.Id));
        return Result<MucGiaThueNhaDetailsDto>.Success(item);

    }
}