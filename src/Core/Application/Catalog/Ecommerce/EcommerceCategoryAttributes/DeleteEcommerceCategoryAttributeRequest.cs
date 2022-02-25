namespace TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;

public class DeleteEcommerceCategoryAttributeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteEcommerceCategoryAttributeRequest(Guid id) => Id = id;
}

public class DeleteEcommerceCategoryAttributeRequestHandler : IRequestHandler<DeleteEcommerceCategoryAttributeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EcommerceCategoryAttribute> _repository;
    private readonly IStringLocalizer<DeleteEcommerceCategoryAttributeRequestHandler> _localizer;

    public DeleteEcommerceCategoryAttributeRequestHandler(IRepositoryWithEvents<EcommerceCategoryAttribute> repository, IStringLocalizer<DeleteEcommerceCategoryAttributeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteEcommerceCategoryAttributeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["EcommerceCategory.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}