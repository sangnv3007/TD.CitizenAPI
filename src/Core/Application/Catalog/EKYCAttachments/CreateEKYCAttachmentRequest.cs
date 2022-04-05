using Microsoft.AspNetCore.Http;
using TD.CitizenAPI.Application.Catalog.Attachments;

namespace TD.CitizenAPI.Application.Catalog.EKYCAttachments;

public class CreateEKYCAttachmentRequest : IRequest<Result<AttachmentDto>>
{
    public IFormFile? File { get; set; }
    public string? ImageType { get; set; }
    public string? UserName { get; set; }
}

public class CreateAttachmentRequestValidator : CustomValidator<CreateEKYCAttachmentRequest>
{
    public CreateAttachmentRequestValidator(IReadRepository<EKYCAttachment> repository, IStringLocalizer<CreateAttachmentRequestValidator> localizer)
    {
        RuleFor(p => p.File)
            .NotEmpty()
                .WithMessage((_) => "Khong co du lieu file");
        RuleFor(p => p.ImageType)
                .NotEmpty()
                    .WithMessage((_) => "ImageType khong duoc de trong");
    }
}

public class EKYCAttachmentByUserNameSpec : Specification<EKYCAttachment>, ISingleResultSpecification
{
    public EKYCAttachmentByUserNameSpec(string? userName, string? imageType) =>
        Query.Where(p => p.UserName == userName && p.ImageType == imageType);
}

public class CreateAttachmentRequestHandler : IRequestHandler<CreateEKYCAttachmentRequest, Result<AttachmentDto>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EKYCAttachment> _repository;
    private readonly IFileStorageService _file;
    private readonly ICurrentUser _currentUser;

    public CreateAttachmentRequestHandler(IRepositoryWithEvents<EKYCAttachment> repository, ICurrentUser currentUser, IFileStorageService file) => (_repository, _currentUser, _file) = (repository, currentUser, file);

    public async Task<Result<AttachmentDto>> Handle(CreateEKYCAttachmentRequest request, CancellationToken cancellationToken)
    {
        string? userName = request.UserName ?? _currentUser.GetUserName();

        var itemAttach = await _repository.GetBySpecAsync(new EKYCAttachmentByUserNameSpec(userName, request.ImageType), cancellationToken);

        var itemEKYCAttachmentDto = await _file.UploadFileAsync<EKYCAttachment>(request.File, cancellationToken);
        if (itemEKYCAttachmentDto != null)
        {

            if (itemAttach != null)
            {
                itemAttach.UserName = userName;
                itemAttach.ImageType = request.ImageType;
                itemAttach.Url = itemEKYCAttachmentDto.Url;
                itemAttach.FileName = itemEKYCAttachmentDto.Name;
                itemAttach.FileType = itemEKYCAttachmentDto.Type;
                await _repository.UpdateAsync(itemAttach, cancellationToken);
                return Result<AttachmentDto>.Success(itemEKYCAttachmentDto);
            }

            if (itemAttach == null)
            {
                var item = new EKYCAttachment();
                item.UserName = userName;
                item.ImageType = request.ImageType;
                item.Url = itemEKYCAttachmentDto.Url;
                item.FileName = itemEKYCAttachmentDto.Name;
                item.FileType = itemEKYCAttachmentDto.Type;
                await _repository.AddAsync(item, cancellationToken);
                return Result<AttachmentDto>.Success(itemEKYCAttachmentDto);
            }
        }
        return Result<AttachmentDto>.Fail();
    }
}