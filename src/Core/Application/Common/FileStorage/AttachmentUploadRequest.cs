using Microsoft.AspNetCore.Http;

namespace TD.CitizenAPI.Application.Common.FileStorage;

public class AttachmentUploadRequest
{
    public List<IFormFile>? Files { get; set; }
}

public class AttachmentUploadRequestValidator : CustomValidator<AttachmentUploadRequest>
{
    public AttachmentUploadRequestValidator()
    {
        RuleFor(p => p.Files)
            .NotEmpty()
                .WithMessage("Files cannot be empty!");
    }
}