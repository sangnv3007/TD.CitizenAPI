namespace TD.CitizenAPI.Application.Catalog.CarPolicies;

public class DeleteCarPolicyRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteCarPolicyRequest(Guid id) => Id = id;
}

public class DeleteCarPolicyRequestHandler : IRequestHandler<DeleteCarPolicyRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CarPolicy> _repository;
    private readonly IReadRepository<Carpool> _carpoolRepo;
    private readonly IStringLocalizer<DeleteCarPolicyRequestHandler> _localizer;

    public DeleteCarPolicyRequestHandler(IRepositoryWithEvents<CarPolicy> repository, IReadRepository<Carpool> carpoolRepo, IStringLocalizer<DeleteCarPolicyRequestHandler> localizer) =>
        (_repository, _carpoolRepo, _localizer) = (repository, carpoolRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteCarPolicyRequest request, CancellationToken cancellationToken)
    {

        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["CarPolicy.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}