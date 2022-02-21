namespace TD.CitizenAPI.Application.Catalog.Industries;

public class DeleteIndustryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteIndustryRequest(Guid id) => Id = id;
}

public class DeleteIndustryRequestHandler : IRequestHandler<DeleteIndustryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Industry> _repository;
    private readonly IStringLocalizer<DeleteIndustryRequestHandler> _localizer;

    public DeleteIndustryRequestHandler(IRepositoryWithEvents<Industry> repository, IStringLocalizer<DeleteIndustryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteIndustryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Industry.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}