namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class AttributeDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsVisibleOnFront { get; set; } = true;
    public bool IsRequired { get; set; } = false;
    public bool IsFilterable { get; set; } = false;
    public bool IsSearchable { get; set; } = false;
    public bool IsEditable { get; set; } = true;
    public bool IsSellerEditable { get; set; } = true;
    public string DefaultValue { get; set; } = default!;
    /*public FrontendInput FrontendInput { get; set; }
    //Datatype : int, decimal, varchar, text, datetime
    public DataType DataType { get; set; }
    public FrontendInput InputType { get; set; }*/
    public string FrontendInput { get; set; } = default!;
    public string DataType { get; set; } = default!;
    public string InputType { get; set; } = default!;

    public bool IsActive { get; set; } = true;
}