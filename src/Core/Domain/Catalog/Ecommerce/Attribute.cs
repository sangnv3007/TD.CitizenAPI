namespace TD.CitizenAPI.Domain.Catalog;

public class Attribute : AuditableEntity, IAggregateRoot
{
    public string Code { get; set; }
    public string DisplayName { get; set; }
    public string? Description { get; set; }
    public bool IsVisibleOnFront { get; set; } = true;
    public bool IsRequired { get; set; } = false;
    public bool IsFilterable { get; set; } = false;
    public bool IsSearchable { get; set; } = false;
    public bool IsEditable { get; set; } = true;
    public bool IsSellerEditable { get; set; } = true;
    public string? DefaultValue { get; set; }
    /*public FrontendInput FrontendInput { get; set; }
    //Datatype : int, decimal, varchar, text, datetime
    public DataType DataType { get; set; }
    public FrontendInput InputType { get; set; }*/
    public string FrontendInput { get; set; }
    public string DataType { get; set; }
    public string InputType { get; set; }

    public bool IsActive { get; set; } = true;


    public virtual ICollection<AttributeDatetime>? AttributeDatetimes { get; set; }

    public virtual ICollection<AttributeDecimal>? AttributeDecimals { get; set; }

    public virtual ICollection<AttributeInt>? AttributeInts { get; set; }
    public virtual ICollection<AttributeBoolean>? AttributeBooleans { get; set; }

    public virtual ICollection<AttributeText>? AttributeTexts { get; set; }
    public virtual ICollection<AttributeVarchar>? AttributeVarchars { get; set; }


    public virtual ICollection<EcommerceCategoryAttribute>? EcommerceCategoryAttributes { get; set; }

    public Attribute(string code, string displayName, string? description, bool isVisibleOnFront, bool isRequired, bool isFilterable, bool isSearchable, bool isEditable, bool isSellerEditable, string? defaultValue, string frontendInput, string dataType, string inputType, bool isActive)
    {
        Code = code;
        DisplayName = displayName;
        Description = description;
        IsVisibleOnFront = isVisibleOnFront;
        IsRequired = isRequired;
        IsFilterable = isFilterable;
        IsSearchable = isSearchable;
        IsEditable = isEditable;
        IsSellerEditable = isSellerEditable;
        DefaultValue = defaultValue;
        FrontendInput = frontendInput;
        DataType = dataType;
        InputType = inputType;
        IsActive = isActive;
    }

    public Attribute Update(string? code, string? displayName, string? description, bool? isVisibleOnFront, bool? isRequired, bool? isFilterable, bool? isSearchable, bool? isEditable, bool? isSellerEditable, string? defaultValue, string? frontendInput, string? dataType, string? inputType, bool? isActive)
    {
        if (displayName is not null && DisplayName?.Equals(displayName) is not true)
        {
            DisplayName = displayName;
        }

        if (code is not null && Code?.Equals(code) is not true)
        {
            Code = code;
        }

        if (defaultValue is not null && DefaultValue?.Equals(defaultValue) is not true)
        {
            DefaultValue = defaultValue;
        }

        if (frontendInput is not null && FrontendInput?.Equals(frontendInput) is not true)
        {
            FrontendInput = frontendInput;
        }

        if (dataType is not null && DataType?.Equals(dataType) is not true)
        {
            DataType = dataType;
        }

        if (inputType is not null && InputType?.Equals(inputType) is not true)
        {
            InputType = inputType;
        }

        if (description is not null && Description?.Equals(description) is not true)
        {
            Description = description;
        }

        if (isVisibleOnFront.HasValue && !IsVisibleOnFront.Equals(isVisibleOnFront.Value))
        {
            IsVisibleOnFront = isVisibleOnFront.Value;
        }

        if (isRequired.HasValue && !IsRequired.Equals(isRequired.Value))
        {
            IsRequired = isRequired.Value;
        }

        if (isFilterable.HasValue && !IsFilterable.Equals(isFilterable.Value))
        {
            IsFilterable = isFilterable.Value;
        }

        if (isSearchable.HasValue && !IsSearchable.Equals(isSearchable.Value))
        {
            IsSearchable = isSearchable.Value;
        }

        if (isEditable.HasValue && !IsEditable.Equals(isEditable.Value))
        {
            IsEditable = isEditable.Value;
        }

        if (isSellerEditable.HasValue && !IsSellerEditable.Equals(isSellerEditable.Value))
        {
            IsSellerEditable = isSellerEditable.Value;
        }

        if (isActive.HasValue && !IsActive.Equals(isActive.Value))
        {
            IsActive = isActive.Value;
        }

        return this;
    }
}