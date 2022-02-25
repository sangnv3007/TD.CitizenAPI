
namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class DeleteEcommerceCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteEcommerceCategoryRequest(Guid id) => Id = id;
}

public class DeleteEcommerceCategoryRequestHandler : IRequestHandler<DeleteEcommerceCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EcommerceCategory> _repository;
    private readonly IStringLocalizer<DeleteEcommerceCategoryRequestHandler> _localizer;

    public DeleteEcommerceCategoryRequestHandler(IRepositoryWithEvents<EcommerceCategory> repository, IStringLocalizer<DeleteEcommerceCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteEcommerceCategoryRequest request, CancellationToken cancellationToken)
    {
        
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["EcommerceCategory.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}