namespace TD.CitizenAPI.Application.Catalog.Degrees;

public class DeleteDegreeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteDegreeRequest(Guid id) => Id = id;
}

public class DeleteDegreeRequestHandler : IRequestHandler<DeleteDegreeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Degree> _repository;
    private readonly IStringLocalizer<DeleteDegreeRequestHandler> _localizer;

    public DeleteDegreeRequestHandler(IRepositoryWithEvents<Degree> repository, IStringLocalizer<DeleteDegreeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteDegreeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["degree.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}