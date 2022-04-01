namespace TD.CitizenAPI.Application.Catalog.ProjectInvestCategories;

public class DeleteProjectInvestCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteProjectInvestCategoryRequest(Guid id) => Id = id;
}

public class DeleteProjectInvestCategoryRequestHandler : IRequestHandler<DeleteProjectInvestCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestCategory> _repository;
    private readonly IStringLocalizer<DeleteProjectInvestCategoryRequestHandler> _localizer;

    public DeleteProjectInvestCategoryRequestHandler(IRepositoryWithEvents<ProjectInvestCategory> repository, IStringLocalizer<DeleteProjectInvestCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteProjectInvestCategoryRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["ProjectInvestCategory.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}