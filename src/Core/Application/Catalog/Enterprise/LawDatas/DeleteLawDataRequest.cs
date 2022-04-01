
namespace TD.CitizenAPI.Application.Catalog.LawDatas;

public class DeleteLawDataRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteLawDataRequest(Guid id) => Id = id;
}

public class DeleteLawDataRequestHandler : IRequestHandler<DeleteLawDataRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LawData> _repository;
    private readonly IStringLocalizer<DeleteLawDataRequestHandler> _localizer;

    public DeleteLawDataRequestHandler(IRepositoryWithEvents<LawData> repository, IStringLocalizer<DeleteLawDataRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteLawDataRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["LawData.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}