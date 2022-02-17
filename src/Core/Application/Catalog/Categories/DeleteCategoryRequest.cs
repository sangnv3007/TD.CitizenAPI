using TD.CitizenAPI.Application.Catalog.PlaceTypes;

namespace TD.CitizenAPI.Application.Catalog.Categories;

public class DeleteCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteCategoryRequest(Guid id) => Id = id;
}

public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Category> _categoryRepo;
    private readonly IReadRepository<PlaceType> _placeTypeRepo;
    private readonly IStringLocalizer<DeleteCategoryRequestHandler> _localizer;

    public DeleteCategoryRequestHandler(IRepositoryWithEvents<Category> categoryRepo, IReadRepository<PlaceType> placeTypeRepo, IStringLocalizer<DeleteCategoryRequestHandler> localizer) =>
        (_categoryRepo, _placeTypeRepo, _localizer) = (categoryRepo, placeTypeRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        if (await _placeTypeRepo.AnyAsync(new PlaceTypesByCategorySpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_localizer["category.cannotbedeleted"]);
        }

        var brand = await _categoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = brand ?? throw new NotFoundException(_localizer["category.notfound"]);

        await _categoryRepo.DeleteAsync(brand, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}