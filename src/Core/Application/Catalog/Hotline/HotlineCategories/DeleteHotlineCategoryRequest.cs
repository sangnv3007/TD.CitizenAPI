using TD.CitizenAPI.Application.Catalog.Hotlines;

namespace TD.CitizenAPI.Application.Catalog.HotlineCategories;

public class DeleteHotlineCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteHotlineCategoryRequest(Guid id) => Id = id;
}

public class DeleteHotlineCategoryRequestHandler : IRequestHandler<DeleteHotlineCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<HotlineCategory> _hotlineCategoryRepo;
    private readonly IReadRepository<Hotline> _hotlineRepo;
    private readonly IStringLocalizer<DeleteHotlineCategoryRequestHandler> _localizer;

    public DeleteHotlineCategoryRequestHandler(IRepositoryWithEvents<HotlineCategory> hotlineCategoryRepo, IReadRepository<Hotline> hotlineRepo, IStringLocalizer<DeleteHotlineCategoryRequestHandler> localizer) =>
        (_hotlineCategoryRepo, _hotlineRepo, _localizer) = (hotlineCategoryRepo, hotlineRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteHotlineCategoryRequest request, CancellationToken cancellationToken)
    {
        if (await _hotlineRepo.AnyAsync(new HotlineByHotlineCategorySpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_localizer["hotlinecategory.cannotbedeleted"]);
        }

        var item = await _hotlineCategoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["hotlinecategory.notfound"]);

        await _hotlineCategoryRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}