
namespace TD.CitizenAPI.Application.Catalog.Diseases;

public class DeleteDiseaseRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteDiseaseRequest(Guid id) => Id = id;
}

public class DeleteDiseaseRequestHandler : IRequestHandler<DeleteDiseaseRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Disease> _DiseaseRepo;
    private readonly IStringLocalizer<DeleteDiseaseRequestHandler> _localizer;

    public DeleteDiseaseRequestHandler(IRepositoryWithEvents<Disease> DiseaseRepo, IStringLocalizer<DeleteDiseaseRequestHandler> localizer) =>
        (_DiseaseRepo,  _localizer) = (DiseaseRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteDiseaseRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _DiseaseRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Disease.notfound"]);

        await _DiseaseRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}