
namespace TD.CitizenAPI.Application.Catalog.DienTichNhas;

public class DeleteDienTichNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteDienTichNhaRequest(Guid id) => Id = id;
}

public class DeleteDienTichNhaRequestHandler : IRequestHandler<DeleteDienTichNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<DienTichNha> _repo;
    private readonly IStringLocalizer<DeleteDienTichNhaRequestHandler> _localizer;

    public DeleteDienTichNhaRequestHandler(IRepositoryWithEvents<DienTichNha> repo, IStringLocalizer<DeleteDienTichNhaRequestHandler> localizer) =>
        (_repo,  _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteDienTichNhaRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["DienTichNha.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}