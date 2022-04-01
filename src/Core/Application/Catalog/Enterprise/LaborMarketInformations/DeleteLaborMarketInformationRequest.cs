namespace TD.CitizenAPI.Application.Catalog.LaborMarketInformations;

public class DeleteLaborMarketInformationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteLaborMarketInformationRequest(Guid id) => Id = id;
}

public class DeleteLaborMarketInformationRequestHandler : IRequestHandler<DeleteLaborMarketInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LaborMarketInformation> _repository;
    private readonly IStringLocalizer<DeleteLaborMarketInformationRequestHandler> _localizer;

    public DeleteLaborMarketInformationRequestHandler(IRepositoryWithEvents<LaborMarketInformation> repository, IStringLocalizer<DeleteLaborMarketInformationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteLaborMarketInformationRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["LaborMarketInformation.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}