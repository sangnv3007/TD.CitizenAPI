using Mapster;
using System.Text;
using System.Text.RegularExpressions;
using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.Areas;

public class CreateAreaRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? ParentCode { get; set; }
    public string? Type { get; set; }
    public int Level { get; set; }
    public string? Description { get; set; }
}

public class CreateCategoryRequestValidator : CustomValidator<CreateAreaRequest>
{
    public CreateCategoryRequestValidator(IReadRepository<Area> repository, IStringLocalizer<CreateCategoryRequestValidator> localizer)
    {
        RuleFor(p => p.Name)
           .NotEmpty()
           .MaximumLength(256).WithMessage("Please specify a name");
        RuleFor(p => p.Type)
          .NotEmpty()
          .MaximumLength(256).WithMessage("Please specify a type");
        RuleFor(p => p.Level).NotNull().LessThanOrEqualTo(4).GreaterThan(0).WithMessage("Please specify a level");
        RuleFor(p => p.Code)
                .NotEmpty()
                .MaximumLength(256)
                .MustAsync(async (code, ct) => await repository.GetBySpecAsync(new AreaByCodeSpec(code), ct) is null)
                    .WithMessage((_, name) => string.Format(localizer["category.alreadyexists"], name));
    }

}

public class CreateAreaRequestHandler : IRequestHandler<CreateAreaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Area> _repository;
    private readonly IStringLocalizer<CreateAreaRequestHandler> _localizer;

    public CreateAreaRequestHandler(IRepositoryWithEvents<Area> repository, IStringLocalizer<CreateAreaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(CreateAreaRequest request, CancellationToken cancellationToken)
    {
        //var area = request.Adapt<Area>();
        var area = new Area(request.Name, request.Code, request.ParentCode, request.Type, request.Level, request.Description);

        area.NameWithType = request.Type + " " + request.Name;
        area.Slug = convert(request.Name);

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

        area.DomainEvents.Add(EntityCreatedEvent.WithEntity(area));

        await _repository.AddAsync(area, cancellationToken);

        return Result<Guid>.Success(area.Id);
    }

    public static string convert(string s)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = s.Normalize(NormalizationForm.FormD);
        return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
    }
}