namespace TD.CitizenAPI.Application.Catalog.EKYCAttachments;

public class AllEKYCAttachmentRequest : IRequest<Result<List<EKYCAttachmentDto>>>
{
    public AllEKYCAttachmentRequest()
    {
    }
}


public class EKYCAttachmentSpec : Specification<EKYCAttachment, EKYCAttachmentDto>, ISingleResultSpecification
{
    public EKYCAttachmentSpec(string? userName) =>
        Query.Where(p => p.UserName == userName);
}

public class AllEKYCAttachmentRequestHandler : IRequestHandler<AllEKYCAttachmentRequest, Result<List<EKYCAttachmentDto>>>
{
    private readonly IRepository<EKYCAttachment> _repository;
    private readonly ICurrentUser _currentUser;

    private readonly IStringLocalizer<AllEKYCAttachmentRequestHandler> _localizer;

    public AllEKYCAttachmentRequestHandler(IRepository<EKYCAttachment> repository, ICurrentUser currentUser, IStringLocalizer<AllEKYCAttachmentRequestHandler> localizer) => (_repository, _currentUser, _localizer) = (repository, currentUser, localizer);

    public async Task<Result<List<EKYCAttachmentDto>>> Handle(AllEKYCAttachmentRequest request, CancellationToken cancellationToken)
    {
        string? userName = _currentUser.GetUserName();

        var list = await _repository.ListAsync(new EKYCAttachmentSpec(userName), cancellationToken);

        return Result<List<EKYCAttachmentDto>>.Success(list);

    }


}