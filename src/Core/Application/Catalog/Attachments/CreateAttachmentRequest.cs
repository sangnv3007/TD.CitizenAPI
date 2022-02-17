using Mapster;
using Microsoft.AspNetCore.Http;

namespace TD.CitizenAPI.Application.Catalog.Attachments;

public class CreateAttachmentRequest : IRequest<Result<List<AttachmentDto>>>
{
    public List<IFormFile>? Files { get; set; }
}

public class CreateAttachmentRequestValidator : CustomValidator<CreateAttachmentRequest>
{
    public CreateAttachmentRequestValidator(IReadRepository<Attachment> repository, IStringLocalizer<CreateAttachmentRequestValidator> localizer) =>
        RuleFor(p => p.Files)
            .NotEmpty()
                .WithMessage((_) => string.Format(localizer["attachment.alreadyexists"]));
}

public class CreateAttachmentRequestHandler : IRequestHandler<CreateAttachmentRequest, Result<List<AttachmentDto>>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Attachment> _repository;
    private readonly IFileStorageService _file;

    public CreateAttachmentRequestHandler(IRepositoryWithEvents<Attachment> repository, IFileStorageService file) => (_repository, _file) = (repository, file);

    public async Task<Result<List<AttachmentDto>>> Handle(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        //var brand = new Brand(request.Name, request.Description);
        //List<Attachment> listFile = new List<Attachment>();
        var listFile = await _file.UploadFilesAsync<Attachment>(request.Files, cancellationToken);
        foreach (var attachment in listFile)
        {
            var item = attachment.Adapt<Attachment>();
            await _repository.AddAsync(item, cancellationToken);

        }
        return Result<List<AttachmentDto>>.Success(listFile);

    }
}