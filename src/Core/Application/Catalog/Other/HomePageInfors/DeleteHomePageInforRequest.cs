namespace TD.CitizenAPI.Application.Catalog.HomePageInfors;

public class DeleteHomePageInforRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteHomePageInforRequest(Guid id) => Id = id;
}

public class DeleteHomePageInforRequestHandler : IRequestHandler<DeleteHomePageInforRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<HomePageInfor> _repo;
    private readonly IStringLocalizer<DeleteHomePageInforRequestHandler> _localizer;

    public DeleteHomePageInforRequestHandler(IRepositoryWithEvents<HomePageInfor> repo, IStringLocalizer<DeleteHomePageInforRequestHandler> localizer) =>
        (_repo, _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteHomePageInforRequest request, CancellationToken cancellationToken)
    {
        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["homepageinfor.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}