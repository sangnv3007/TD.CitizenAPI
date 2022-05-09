
namespace TD.CitizenAPI.Application.Catalog.LoaiNhas;

public class DeleteLoaiNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteLoaiNhaRequest(Guid id) => Id = id;
}

public class DeleteLoaiNhaRequestHandler : IRequestHandler<DeleteLoaiNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LoaiNha> _repo;
    private readonly IStringLocalizer<DeleteLoaiNhaRequestHandler> _localizer;

    public DeleteLoaiNhaRequestHandler(IRepositoryWithEvents<LoaiNha> repo, IStringLocalizer<DeleteLoaiNhaRequestHandler> localizer) =>
        (_repo,  _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteLoaiNhaRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["LoaiNha.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}