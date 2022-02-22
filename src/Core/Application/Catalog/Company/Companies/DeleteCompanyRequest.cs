namespace TD.CitizenAPI.Application.Catalog.Companies;

public class DeleteCompanyRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteCompanyRequest(Guid id) => Id = id;
}

public class DeleteCompanyRequestHandler : IRequestHandler<DeleteCompanyRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Company> _repository;
    private readonly IStringLocalizer<DeleteCompanyRequestHandler> _localizer;

    public DeleteCompanyRequestHandler(IRepositoryWithEvents<Company> repository, IStringLocalizer<DeleteCompanyRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Company.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}