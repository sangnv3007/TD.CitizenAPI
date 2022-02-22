namespace TD.CitizenAPI.Application.Catalog.Salaries;

public class DeleteSalaryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteSalaryRequest(Guid id) => Id = id;
}

public class DeleteSalaryRequestHandler : IRequestHandler<DeleteSalaryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Salary> _repository;
    private readonly IStringLocalizer<DeleteSalaryRequestHandler> _localizer;

    public DeleteSalaryRequestHandler(IRepositoryWithEvents<Salary> repository, IStringLocalizer<DeleteSalaryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteSalaryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Salary.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}