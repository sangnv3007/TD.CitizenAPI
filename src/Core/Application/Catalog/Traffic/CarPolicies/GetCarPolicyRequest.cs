namespace TD.CitizenAPI.Application.Catalog.CarPolicies;

public class GetCarPolicyRequest : IRequest<Result<CarPolicyDetailsDto>>
{
    public Guid Id { get; set; }

    public GetCarPolicyRequest(Guid id) => Id = id;
}

public class CarPolicyByIdSpec : Specification<CarPolicy, CarPolicyDetailsDto>, ISingleResultSpecification
{
    public CarPolicyByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCarPolicyRequestHandler : IRequestHandler<GetCarPolicyRequest, Result<CarPolicyDetailsDto>>
{
    private readonly IRepository<CarPolicy> _repository;
    private readonly IStringLocalizer<GetCarPolicyRequestHandler> _localizer;

    public GetCarPolicyRequestHandler(IRepository<CarPolicy> repository, IStringLocalizer<GetCarPolicyRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<CarPolicyDetailsDto>> Handle(GetCarPolicyRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<CarPolicy, CarPolicyDetailsDto>)new CarPolicyByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["carpolicy.notfound"], request.Id));
        return Result<CarPolicyDetailsDto>.Success(item);

    }
}