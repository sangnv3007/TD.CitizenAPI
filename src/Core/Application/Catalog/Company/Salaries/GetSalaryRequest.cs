namespace TD.CitizenAPI.Application.Catalog.Salaries;

public class GetSalaryRequest : IRequest<Result<SalaryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetSalaryRequest(Guid id) => Id = id;
}

public class SalaryByIdSpec : Specification<Salary, SalaryDetailsDto>, ISingleResultSpecification
{
    public SalaryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSalaryRequestHandler : IRequestHandler<GetSalaryRequest, Result<SalaryDetailsDto>>
{
    private readonly IRepository<Salary> _repository;
    private readonly IStringLocalizer<GetSalaryRequestHandler> _localizer;

    public GetSalaryRequestHandler(IRepository<Salary> repository, IStringLocalizer<GetSalaryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<SalaryDetailsDto>> Handle(GetSalaryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Salary, SalaryDetailsDto>)new SalaryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Salary.notfound"], request.Id));
        return Result<SalaryDetailsDto>.Success(item);

    }
}