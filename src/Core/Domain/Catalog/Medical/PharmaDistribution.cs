namespace TD.CitizenAPI.Domain.Catalog;

public class PharmaDistribution : AuditableEntity, IAggregateRoot
{
    public string? Code { get; set; }
    public string? Title { get; set; }
    public string? NamePerson { get; set; }
    public string? NamePersonCMT { get; set; }
    public string? Qualification { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? BusinessAddress { get; set; }
    public string? PhoneContact { get; set; }
    public string? BusinessForm { get; set; }
    public string? NumberDkkd { get; set; }
    public string? DkkdDate { get; set; }
    public string? FormOfGrant { get; set; }
    public string? DkkdIssuedBy { get; set; }
    public string? BusinessScope { get; set; }
    public string? NumberGdp { get; set; }
    public string? GdpDate { get; set; }
    public string? ExpirationGdpDate { get; set; }
    public string? RangeGdp { get; set; }
    public string? ResponseLevel { get; set; }
    public string? WithdrawalDate { get; set; }
    public string? NumberCCHN { get; set; }
    public string? CchnDate { get; set; }
    public string? CchnIssuedBy { get; set; }
    public string? Year { get; set; }
    public string? Note { get; set; }

    public PharmaDistribution(string? code, string? title, string? namePerson, string? namePersonCMT, string? qualification, string? phoneNumber, string? address, string? businessAddress, string? phoneContact, string? businessForm, string? numberDkkd, string? dkkdDate, string? formOfGrant, string? dkkdIssuedBy, string? businessScope, string? numberGdp, string? gdpDate, string? expirationGdpDate, string? rangeGdp, string? responseLevel, string? withdrawalDate, string? numberCCHN, string? cchnDate, string? cchnIssuedBy, string? year, string? note)
    {
        Code = code;
        Title = title;
        NamePerson = namePerson;
        NamePersonCMT = namePersonCMT;
        Qualification = qualification;
        PhoneNumber = phoneNumber;
        Address = address;
        BusinessAddress = businessAddress;
        PhoneContact = phoneContact;
        BusinessForm = businessForm;
        NumberDkkd = numberDkkd;
        DkkdDate = dkkdDate;
        FormOfGrant = formOfGrant;
        DkkdIssuedBy = dkkdIssuedBy;
        BusinessScope = businessScope;
        NumberGdp = numberGdp;
        GdpDate = gdpDate;
        ExpirationGdpDate = expirationGdpDate;
        RangeGdp = rangeGdp;
        ResponseLevel = responseLevel;
        WithdrawalDate = withdrawalDate;
        NumberCCHN = numberCCHN;
        CchnDate = cchnDate;
        CchnIssuedBy = cchnIssuedBy;
        Year = year;
        Note = note;
    }

    public PharmaDistribution Update(string? code, string? title, string? namePerson, string? namePersonCMT, string? qualification, string? phoneNumber, string? address, string? businessAddress, string? phoneContact, string? businessForm, string? numberDkkd, string? dkkdDate, string? formOfGrant, string? dkkdIssuedBy, string? businessScope, string? numberGdp, string? gdpDate, string? expirationGdpDate, string? rangeGdp, string? responseLevel, string? withdrawalDate, string? numberCCHN, string? cchnDate, string? cchnIssuedBy, string? year, string? note)
    {
        Code = code;
        Title = title;
        NamePerson = namePerson;
        NamePersonCMT = namePersonCMT;
        Qualification = qualification;
        PhoneNumber = phoneNumber;
        Address = address;
        BusinessAddress = businessAddress;
        PhoneContact = phoneContact;
        BusinessForm = businessForm;
        NumberDkkd = numberDkkd;
        DkkdDate = dkkdDate;
        FormOfGrant = formOfGrant;
        DkkdIssuedBy = dkkdIssuedBy;
        BusinessScope = businessScope;
        NumberGdp = numberGdp;
        GdpDate = gdpDate;
        ExpirationGdpDate = expirationGdpDate;
        RangeGdp = rangeGdp;
        ResponseLevel = responseLevel;
        WithdrawalDate = withdrawalDate;
        NumberCCHN = numberCCHN;
        CchnDate = cchnDate;
        CchnIssuedBy = cchnIssuedBy;
        Year = year;
        Note = note;
        return this;
    }
}