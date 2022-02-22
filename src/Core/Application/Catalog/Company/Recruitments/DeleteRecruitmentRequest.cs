namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class DeleteRecruitmentRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteRecruitmentRequest(Guid id) => Id = id;
}

public class DeleteRecruitmentRequestHandler : IRequestHandler<DeleteRecruitmentRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Recruitment> _repository;
    private readonly IStringLocalizer<DeleteRecruitmentRequestHandler> _localizer;

    public DeleteRecruitmentRequestHandler(IRepositoryWithEvents<Recruitment> repository, IStringLocalizer<DeleteRecruitmentRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteRecruitmentRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Recruitment.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}