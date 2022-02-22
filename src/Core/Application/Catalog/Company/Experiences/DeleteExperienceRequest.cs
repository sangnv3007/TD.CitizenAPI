namespace TD.CitizenAPI.Application.Catalog.Experiences;

public class DeleteExperienceRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteExperienceRequest(Guid id) => Id = id;
}

public class DeleteExperienceRequestHandler : IRequestHandler<DeleteExperienceRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Experience> _repository;
    private readonly IStringLocalizer<DeleteExperienceRequestHandler> _localizer;

    public DeleteExperienceRequestHandler(IRepositoryWithEvents<Experience> repository, IStringLocalizer<DeleteExperienceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteExperienceRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Experience.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}