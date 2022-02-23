using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TD.CitizenAPI.Application.Catalog.Attachments;
using TD.CitizenAPI.Application.Common.FileStorage;
using TD.CitizenAPI.Domain.Common;
using TD.CitizenAPI.Infrastructure.Common.Extensions;

namespace TD.CitizenAPI.Infrastructure.FileStorage;

public class LocalFileStorageService : IFileStorageService
{
    public async Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default)
    where T : class
    {
        if (request == null || request.Data == null)
        {
            return string.Empty;
        }

        if (request.Extension is null || !supportedFileType.GetDescriptionList().Contains(request.Extension.ToLower()))
            throw new InvalidOperationException("File Format Not Supported.");
        if (request.Name is null)
            throw new InvalidOperationException("Name is required.");

        string base64Data = Regex.Match(request.Data, "data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;

        var streamData = new MemoryStream(Convert.FromBase64String(base64Data));
        if (streamData.Length > 0)
        {
            string folder = typeof(T).Name;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                folder = folder.Replace(@"\", "/");
            }

            string folderName = supportedFileType switch
            {
                FileType.Image => Path.Combine("Files", "Images", folder),
                _ => Path.Combine("Files", "Others", folder),
            };
            string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            Directory.CreateDirectory(pathToSave);

            string fileName = request.Name.Trim('"');
            fileName = RemoveSpecialCharacters(fileName);
            fileName = fileName.ReplaceWhitespace("-");
            fileName += request.Extension.Trim();
            string fullPath = Path.Combine(pathToSave, fileName);
            string dbPath = Path.Combine(folderName, fileName);
            if (File.Exists(dbPath))
            {
                dbPath = NextAvailableFilename(dbPath);
                fullPath = NextAvailableFilename(fullPath);
            }

            using var stream = new FileStream(fullPath, FileMode.Create);
            await streamData.CopyToAsync(stream, cancellationToken);
            return dbPath.Replace("\\", "/");
        }
        else
        {
            return string.Empty;
        }
    }

    public async Task<List<AttachmentDto>> UploadFilesAsync<T>(List<IFormFile>? files, CancellationToken cancellationToken = default)
    where T : class
    {
        List<AttachmentDto> listFile = new List<AttachmentDto>();
#pragma warning disable CS8604 // Possible null reference argument.
        long size = files.Sum(f => f.Length);
#pragma warning restore CS8604 // Possible null reference argument.

        if (files.Any(f => f.Length == 0))
        {
            throw new InvalidOperationException("File Not Found.");
        }


        string folder = typeof(T).Name;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            folder = folder.Replace(@"\", "/");
        }

        string folderName = Path.Combine("Files", "Others", folder);

        string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        bool exists = Directory.Exists(pathToSave);
        if (!exists)
        {
            Directory.CreateDirectory(pathToSave);
        }

        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                string? fileName = formFile.FileName.Trim('"');
                fileName = RemoveSpecialCharacters(fileName);
                fileName = fileName.ReplaceWhitespace("-");

                Guid dir_UUID = Guid.NewGuid();
                string dir_UUID_String = dir_UUID.ToString();


                string? target = Path.Combine(pathToSave, dir_UUID_String);
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }

                string? fullPath = Path.Combine(target, fileName);
                string? dbPath = Path.Combine(folderName, dir_UUID_String, fileName);

                if (File.Exists(dbPath))
                {
                    dbPath = NextAvailableFilename(dbPath);
                    fullPath = NextAvailableFilename(fullPath);
                }

                using var stream = new FileStream(fullPath, FileMode.Create);
                await formFile.CopyToAsync(stream, cancellationToken);

                //formFile.CopyTo(stream);
                dbPath = dbPath.Replace("\\", "/");


                var attachment = new AttachmentDto();
                attachment.Name = fileName;
                attachment.Type = Path.GetExtension(formFile.FileName);
                attachment.Url = dbPath;

                listFile.Add(attachment);

            }
        }

        return await Task.FromResult(listFile);
    }


    public async Task<AttachmentDto> UploadFileAsync<T>(IFormFile? formFile, CancellationToken cancellationToken = default)
    where T : class
    {
        var attachment = new AttachmentDto();
        string folder = typeof(T).Name;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            folder = folder.Replace(@"\", "/");
        }

        string folderName = Path.Combine("Files", "Others", folder);

        string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        bool exists = Directory.Exists(pathToSave);
        if (!exists)
        {
            Directory.CreateDirectory(pathToSave);
        }


        if (formFile != null && formFile.Length > 0)
            {
                string? fileName = formFile.FileName.Trim('"');
                fileName = RemoveSpecialCharacters(fileName);
                fileName = fileName.ReplaceWhitespace("-");

                Guid dir_UUID = Guid.NewGuid();
                string dir_UUID_String = dir_UUID.ToString();


                string? target = Path.Combine(pathToSave, dir_UUID_String);
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }

                string? fullPath = Path.Combine(target, fileName);
                string? dbPath = Path.Combine(folderName, dir_UUID_String, fileName);

                if (File.Exists(dbPath))
                {
                    dbPath = NextAvailableFilename(dbPath);
                    fullPath = NextAvailableFilename(fullPath);
                }

                using var stream = new FileStream(fullPath, FileMode.Create);
                await formFile.CopyToAsync(stream, cancellationToken);

                //formFile.CopyTo(stream);
                dbPath = dbPath.Replace("\\", "/");


                attachment.Name = fileName;
                attachment.Type = Path.GetExtension(formFile.FileName);
                attachment.Url = dbPath;

        }

        return await Task.FromResult(attachment);
    }

    public static string RemoveSpecialCharacters(string str)
    {
        return Regex.Replace(str, "[^a-zA-Z0-9_.]+", string.Empty, RegexOptions.Compiled);
    }

    public void Remove(string? path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    private const string NumberPattern = "-{0}";

    private static string NextAvailableFilename(string path)
    {
        if (!File.Exists(path))
        {
            return path;
        }

        if (Path.HasExtension(path))
        {
            return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path), StringComparison.Ordinal), NumberPattern));
        }

        return GetNextFilename(path + NumberPattern);
    }

    private static string GetNextFilename(string pattern)
    {
        string tmp = string.Format(pattern, 1);

        if (!File.Exists(tmp))
        {
            return tmp;
        }

        int min = 1, max = 2;

        while (File.Exists(string.Format(pattern, max)))
        {
            min = max;
            max *= 2;
        }

        while (max != min + 1)
        {
            int pivot = (max + min) / 2;
            if (File.Exists(string.Format(pattern, pivot)))
            {
                min = pivot;
            }
            else
            {
                max = pivot;
            }
        }

        return string.Format(pattern, max);
    }
}