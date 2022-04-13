
namespace TD.CitizenAPI.Application.Catalog.FoodWarnings;

public class DeleteFoodWarningRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteFoodWarningRequest(Guid id) => Id = id;
}

public class DeleteFoodWarningRequestHandler : IRequestHandler<DeleteFoodWarningRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FoodWarning> _repo;
    private readonly IStringLocalizer<DeleteFoodWarningRequestHandler> _localizer;

    public DeleteFoodWarningRequestHandler(IRepositoryWithEvents<FoodWarning> repo, IStringLocalizer<DeleteFoodWarningRequestHandler> localizer) =>
        (_repo,  _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteFoodWarningRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["FoodWarning.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}