namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class UpdateEcommerceCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; } = default!;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public int? Position { get; set; }
    public bool? IncludeInMenu { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string[]? Tags
    {
        get; set;
    }
    public bool? isActive { get; set; }
    public int? status { get; set; }

    public class UpdateEcommerceCategoryRequestValidator : CustomValidator<UpdateEcommerceCategoryRequest>
    {
        public UpdateEcommerceCategoryRequestValidator(IRepository<EcommerceCategory> repository, IStringLocalizer<UpdateEcommerceCategoryRequestValidator> localizer) =>
            RuleFor(p => p.Name)
                .NotEmpty();
    }

    public class UpdateEcommerceCategoryRequestHandler : IRequestHandler<UpdateEcommerceCategoryRequest, Result<Guid>>
    {
        // Add Domain Events automatically by using IRepositoryWithEvents
        private readonly IRepositoryWithEvents<EcommerceCategory> _repository;
        private readonly IStringLocalizer<UpdateEcommerceCategoryRequestHandler> _localizer;

        public UpdateEcommerceCategoryRequestHandler(IRepositoryWithEvents<EcommerceCategory> repository, IStringLocalizer<UpdateEcommerceCategoryRequestHandler> localizer) =>
            (_repository, _localizer) = (repository, localizer);

        public async Task<Result<Guid>> Handle(UpdateEcommerceCategoryRequest request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _ = item ?? throw new NotFoundException(string.Format(_localizer["EcommerceCategory.notfound"], request.Id));


            if (request.ParentId == null)
            {
                item.Level = 1;
            }
            else
            {
                var category = await _repository.GetByIdAsync((Guid)request.ParentId, cancellationToken);
                _ = category ?? throw new NotFoundException(_localizer["parentecommercecategory.notfound"]);

                item.Level = category.Level + 1;

            }


            item.Update(request.ParentId, request.Name, request.Slug, request.Description, request.MetaTitle, request.MetaDescription, request.Position, request.IncludeInMenu, item.Level, request.Icon, request.Image, request.Tags, request.status, request.isActive);

            await _repository.UpdateAsync(item, cancellationToken);

            return Result<Guid>.Success(request.Id);
        }
    }
}