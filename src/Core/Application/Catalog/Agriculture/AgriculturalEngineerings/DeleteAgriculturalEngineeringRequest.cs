namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class DeleteAgriculturalEngineeringRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAgriculturalEngineeringRequest(Guid id) => Id = id;
}

public class DeleteAgriculturalEngineeringRequestHandler : IRequestHandler<DeleteAgriculturalEngineeringRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AgriculturalEngineering> _repository;
    private readonly IStringLocalizer<DeleteAgriculturalEngineeringRequestHandler> _localizer;

    public DeleteAgriculturalEngineeringRequestHandler(IRepositoryWithEvents<AgriculturalEngineering> repository, IStringLocalizer<DeleteAgriculturalEngineeringRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteAgriculturalEngineeringRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AgriculturalEngineering.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}