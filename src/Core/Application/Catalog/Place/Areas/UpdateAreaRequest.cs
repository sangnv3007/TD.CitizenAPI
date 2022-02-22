using Mapster;
using System.Text;
using System.Text.RegularExpressions;

namespace TD.CitizenAPI.Application.Catalog.Areas;

public class UpdateAreaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? ParentCode { get; set; }
    public string? Type { get; set; }
    public int Level { get; set; }
    public string? Description { get; set; }
}

public class UpdateAreaRequestValidator : CustomValidator<UpdateAreaRequest>
{
    public UpdateAreaRequestValidator(IRepository<Area> repository, IStringLocalizer<UpdateAreaRequestValidator> localizer) =>
        RuleFor(p => p.Code)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (category, code, ct) =>
                    await repository.GetBySpecAsync(new AreaByCodeSpec(code), ct)
                        is not Area existingCategory || existingCategory.Id == category.Id)
                .WithMessage((_, code) => string.Format(localizer["area.alreadyexists"], code));
}

public class UpdateAreaRequestHandler : IRequestHandler<UpdateAreaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Area> _repository;
    private readonly IStringLocalizer<UpdateAreaRequestHandler> _localizer;

    public UpdateAreaRequestHandler(IRepositoryWithEvents<Area> repository, IStringLocalizer<UpdateAreaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAreaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["area.notfound"], request.Id));

        var area = request.Adapt<Area>();
        area.NameWithType = request.Type ?? item.Type + " " + request.Name ?? item.Name;
        area.Slug = convert(request.Name ?? item.Name);
        string path = area.Name;
        string pathWithType = area.NameWithType;

        if (!string.IsNullOrWhiteSpace(request.ParentCode))
        {
            var parentArea = await _repository.GetBySpecAsync(new AreaByCodeSpec(request.ParentCode), cancellationToken);
            _ = parentArea ?? throw new NotFoundException(string.Format(_localizer["category.parentnotfound"], request.ParentCode));
            path = area.Name + ", " + parentArea.Path;
            pathWithType = area.NameWithType + ", " + parentArea.PathWithType;
        }

        area.Path = path;
        area.PathWithType = pathWithType;

        item.Update(request.Name, request.Code, request.ParentCode, area.Slug, request.Type, request.Level, area.NameWithType, area.Path, area.PathWithType, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }

    public static string convert(string s)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = s.Normalize(NormalizationForm.FormD);
        return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
    }
}