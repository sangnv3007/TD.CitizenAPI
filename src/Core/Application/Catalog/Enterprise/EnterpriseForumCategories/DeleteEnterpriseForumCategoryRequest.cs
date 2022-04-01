namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumCategories;

public class DeleteEnterpriseForumCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteEnterpriseForumCategoryRequest(Guid id) => Id = id;
}

public class DeleteEnterpriseForumCategoryRequestHandler : IRequestHandler<DeleteEnterpriseForumCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumCategory> _repository;
    private readonly IStringLocalizer<DeleteEnterpriseForumCategoryRequestHandler> _localizer;

    public DeleteEnterpriseForumCategoryRequestHandler(IRepositoryWithEvents<EnterpriseForumCategory> repository, IStringLocalizer<DeleteEnterpriseForumCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteEnterpriseForumCategoryRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["EnterpriseForumCategory.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}