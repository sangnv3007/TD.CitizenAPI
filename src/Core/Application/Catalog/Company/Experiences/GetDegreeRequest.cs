namespace TD.CitizenAPI.Application.Catalog.Experiences;

public class GetExperienceRequest : IRequest<Result<ExperienceDetailsDto>>
{
    public Guid Id { get; set; }

    public GetExperienceRequest(Guid id) => Id = id;
}

public class ExperienceByIdSpec : Specification<Experience, ExperienceDetailsDto>, ISingleResultSpecification
{
    public ExperienceByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetExperienceRequestHandler : IRequestHandler<GetExperienceRequest, Result<ExperienceDetailsDto>>
{
    private readonly IRepository<Experience> _repository;
    private readonly IStringLocalizer<GetExperienceRequestHandler> _localizer;

    public GetExperienceRequestHandler(IRepository<Experience> repository, IStringLocalizer<GetExperienceRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<ExperienceDetailsDto>> Handle(GetExperienceRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Experience, ExperienceDetailsDto>)new ExperienceByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Experience.notfound"], request.Id));
        return Result<ExperienceDetailsDto>.Success(item);

    }
}