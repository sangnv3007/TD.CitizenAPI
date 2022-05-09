
namespace TD.CitizenAPI.Application.Catalog.ThueNhas;

public class DeleteThueNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteThueNhaRequest(Guid id) => Id = id;
}

public class DeleteThueNhaRequestHandler : IRequestHandler<DeleteThueNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ThueNha> _repo;
    private readonly IStringLocalizer<DeleteThueNhaRequestHandler> _localizer;

    public DeleteThueNhaRequestHandler(IRepositoryWithEvents<ThueNha> repo, IStringLocalizer<DeleteThueNhaRequestHandler> localizer) =>
        (_repo,  _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteThueNhaRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["ThueNha.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}