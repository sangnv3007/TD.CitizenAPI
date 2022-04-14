namespace TD.CitizenAPI.Application.Catalog.FoodFactories;

public class DeleteFoodFactoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteFoodFactoryRequest(Guid id) => Id = id;
}

public class DeleteFoodFactoryRequestHandler : IRequestHandler<DeleteFoodFactoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FoodFactory> _repo;
    private readonly IStringLocalizer<DeleteFoodFactoryRequestHandler> _localizer;

    public DeleteFoodFactoryRequestHandler(IRepositoryWithEvents<FoodFactory> repo, IStringLocalizer<DeleteFoodFactoryRequestHandler> localizer) =>
        (_repo,  _localizer) = (repo, localizer);

    public async Task<Result<Guid>> Handle(DeleteFoodFactoryRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _repo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["FoodFactory.notfound"]);

        await _repo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}