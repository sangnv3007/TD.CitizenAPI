namespace TD.CitizenAPI.Application.Identity.Users.Password;

public class ForgotPasswordRequest
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

}

/*public class ForgotPasswordRequestValidator : CustomValidator<ForgotPasswordRequest>
{
    public ForgotPasswordRequestValidator() =>
        RuleFor(p => p.Email).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
                .WithMessage("Invalid Email Address.");
}*/