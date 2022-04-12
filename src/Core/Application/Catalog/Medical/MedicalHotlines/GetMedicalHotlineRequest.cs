namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class GetMedicalHotlineRequest : IRequest<Result<MedicalHotlineDetailsDto>>
{
    public Guid Id { get; set; }

    public GetMedicalHotlineRequest(Guid id) => Id = id;
}

public class GetMedicalHotlineRequestHandler : IRequestHandler<GetMedicalHotlineRequest, Result<MedicalHotlineDetailsDto>>
{
    private readonly IRepository<MedicalHotline> _repository;
    private readonly IStringLocalizer<GetMedicalHotlineRequestHandler> _localizer;

    public GetMedicalHotlineRequestHandler(IRepository<MedicalHotline> repository, IStringLocalizer<GetMedicalHotlineRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<MedicalHotlineDetailsDto>> Handle(GetMedicalHotlineRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<MedicalHotline, MedicalHotlineDetailsDto>)new MedicalHotlineByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["MedicalHotline.notfound"], request.Id));
        return Result<MedicalHotlineDetailsDto>.Success(item);

    }
}