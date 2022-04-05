using Microsoft.AspNetCore.Http;
using TD.CitizenAPI.Application.Catalog.Attachments;

namespace TD.CitizenAPI.Application.Common.FileStorage;

public interface IFileStorageService : ITransientService
{
    public Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default)
    where T : class;

    public Task<List<AttachmentDto>> UploadFilesAsync<T>(List<IFormFile>? files, CancellationToken cancellationToken = default)
    where T : class;

/*    public Task<EKYCAttachmentDto> UploadFilesAsync<T>(IFormFile>? file, CancellationToken cancellationToken = default)
where T : class;*/

    public Task<AttachmentDto> UploadFileAsync<T>(IFormFile? file, CancellationToken cancellationToken = default)
   where T : class;

    public void Remove(string? path);
}