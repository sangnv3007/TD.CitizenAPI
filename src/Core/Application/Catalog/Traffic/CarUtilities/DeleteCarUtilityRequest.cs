using TD.CitizenAPI.Application.Catalog.Carpools;

namespace TD.CitizenAPI.Application.Catalog.CarUtilities;

public class DeleteCarUtilityRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteCarUtilityRequest(Guid id) => Id = id;
}

public class DeleteCarUtilityRequestHandler : IRequestHandler<DeleteCarUtilityRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CarUtility> _repository;
    private readonly IReadRepository<Carpool> _carpoolRepo;
    private readonly IStringLocalizer<DeleteCarUtilityRequestHandler> _localizer;

    public DeleteCarUtilityRequestHandler(IRepositoryWithEvents<CarUtility> repository, IReadRepository<Carpool> carpoolRepo, IStringLocalizer<DeleteCarUtilityRequestHandler> localizer) =>
        (_repository, _carpoolRepo, _localizer) = (repository, carpoolRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteCarUtilityRequest request, CancellationToken cancellationToken)
    {
 

        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["CarUtility.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}