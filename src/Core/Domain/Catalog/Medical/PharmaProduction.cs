namespace TD.CitizenAPI.Domain.Catalog;

public class PharmaProduction : AuditableEntity, IAggregateRoot
{
    public string? CodeId { get; set; }
    public string? Images { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public string? NamePerson { get; set; }
    public string? Qualification { get; set; }
    public string? Phone { get; set; }
    public string? HeadquarterAddress { get; set; }
    public string? BusinessAddress { get; set; }
    public string? ContactPhone { get; set; }
    public string? BusinessForm { get; set; }
    public string? NumberDkkd { get; set; }
    public string? DateDkkd { get; set; }
    public string? FormOfGrant { get; set; }
    public string? DkkdIssuedBy { get; set; }
    public string? BusinessScope { get; set; }
    public string? NumberGdp { get; set; }
    public string? DateGdp { get; set; }
    public string? ExpirationDateGdp { get; set; }
    public string? RangeGdp { get; set; }
    public string? NumberCCHN { get; set; }
    public string? DateCCHN { get; set; }
    public string? CchnIssuedBy { get; set; }
    public string? Year { get; set; }
    public string? Code { get; set; }

    public PharmaProduction(string? codeId, string? images, string? name, string? displayName, string? namePerson, string? qualification, string? phone, string? headquarterAddress, string? businessAddress, string? contactPhone, string? businessForm, string? numberDkkd, string? dateDkkd, string? formOfGrant, string? dkkdIssuedBy, string? businessScope, string? numberGdp, string? dateGdp, string? expirationDateGdp, string? rangeGdp, string? numberCCHN, string? dateCCHN, string? cchnIssuedBy, string? year, string? code)
    {
        CodeId = codeId;
        Images = images;
        Name = name;
        DisplayName = displayName;
        NamePerson = namePerson;
        Qualification = qualification;
        Phone = phone;
        HeadquarterAddress = headquarterAddress;
        BusinessAddress = businessAddress;
        ContactPhone = contactPhone;
        BusinessForm = businessForm;
        NumberDkkd = numberDkkd;
        DateDkkd = dateDkkd;
        FormOfGrant = formOfGrant;
        DkkdIssuedBy = dkkdIssuedBy;
        BusinessScope = businessScope;
        NumberGdp = numberGdp;
        DateGdp = dateGdp;
        ExpirationDateGdp = expirationDateGdp;
        RangeGdp = rangeGdp;
        NumberCCHN = numberCCHN;
        DateCCHN = dateCCHN;
        CchnIssuedBy = cchnIssuedBy;
        Year = year;
        Code = code;
    }

    public PharmaProduction Update(string? codeId, string? images, string? name, string? displayName, string? namePerson, string? qualification, string? phone, string? headquarterAddress, string? businessAddress, string? contactPhone, string? businessForm, string? numberDkkd, string? dateDkkd, string? formOfGrant, string? dkkdIssuedBy, string? businessScope, string? numberGdp, string? dateGdp, string? expirationDateGdp, string? rangeGdp, string? numberCCHN, string? dateCCHN, string? cchnIssuedBy, string? year, string? code)
    {
        CodeId = codeId;
        Images = images;
        Name = name;
        DisplayName = displayName;
        NamePerson = namePerson;
        Qualification = qualification;
        Phone = phone;
        HeadquarterAddress = headquarterAddress;
        BusinessAddress = businessAddress;
        ContactPhone = contactPhone;
        BusinessForm = businessForm;
        NumberDkkd = numberDkkd;
        DateDkkd = dateDkkd;
        FormOfGrant = formOfGrant;
        DkkdIssuedBy = dkkdIssuedBy;
        BusinessScope = businessScope;
        NumberGdp = numberGdp;
        DateGdp = dateGdp;
        ExpirationDateGdp = expirationDateGdp;
        RangeGdp = rangeGdp;
        NumberCCHN = numberCCHN;
        DateCCHN = dateCCHN;
        CchnIssuedBy = cchnIssuedBy;
        Year = year;
        Code = code;
        return this;
    }
}