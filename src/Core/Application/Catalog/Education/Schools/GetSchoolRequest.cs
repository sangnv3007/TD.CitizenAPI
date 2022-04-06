namespace TD.CitizenAPI.Application.Catalog.Schools;

public class GetSchoolRequest : IRequest<Result<SchoolDetailsDto>>
{
    public Guid Id { get; set; }

    public GetSchoolRequest(Guid id) => Id = id;
}

public class SchoolByIdSpec : Specification<School, SchoolDetailsDto>, ISingleResultSpecification
{
    public SchoolByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSchoolRequestHandler : IRequestHandler<GetSchoolRequest, Result<SchoolDetailsDto>>
{
    private readonly IRepository<School> _repository;
    private readonly IStringLocalizer<GetSchoolRequestHandler> _localizer;

    public GetSchoolRequestHandler(IRepository<School> repository, IStringLocalizer<GetSchoolRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<SchoolDetailsDto>> Handle(GetSchoolRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<School, SchoolDetailsDto>)new SchoolByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["School.notfound"], request.Id));
        return Result<SchoolDetailsDto>.Success(item);

    }
}