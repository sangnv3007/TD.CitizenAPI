
namespace TD.CitizenAPI.Application.Catalog.Benefits;

public class DeleteBenefitRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteBenefitRequest(Guid id) => Id = id;
}

public class DeleteBenefitRequestHandler : IRequestHandler<DeleteBenefitRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Benefit> _repository;
    private readonly IStringLocalizer<DeleteBenefitRequestHandler> _localizer;

    public DeleteBenefitRequestHandler(IRepositoryWithEvents<Benefit> repository, IStringLocalizer<DeleteBenefitRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteBenefitRequest request, CancellationToken cancellationToken)
    {
        
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["benefit.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}