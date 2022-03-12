namespace TD.CitizenAPI.Application.Identity.Users;

public class CreateUserRequestValidator : CustomValidator<CreateUserRequest>
{
    public CreateUserRequestValidator(IUserService userService, IStringLocalizer<CreateUserRequestValidator> localizer)
    {
        RuleFor(u => u.Email).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress()
                .WithMessage(localizer["Email không đúng định dạng."])
            .MustAsync(async (email, _) => !await userService.ExistsWithEmailAsync(email))
                .WithMessage((_, email) => string.Format(localizer["Email {0} đã được đăng ký."], email));

        RuleFor(u => u.UserName).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(6)
            .MustAsync(async (name, _) => !await userService.ExistsWithNameAsync(name))
                .WithMessage((_, name) => string.Format(localizer["Tài khoản {0} đã tồn tại trong hệ thống."], name));

        RuleFor(u => u.PhoneNumber).Cascade(CascadeMode.Stop)
            .MustAsync(async (phone, _) => !await userService.ExistsWithPhoneNumberAsync(phone!))
                .WithMessage((_, phone) => string.Format(localizer["Số điện thoại {0} đã tồn tại trong hệ thống."], phone))
                .Unless(u => string.IsNullOrWhiteSpace(u.PhoneNumber));
        /*RuleFor(u => u.IdentityNumber).Cascade(CascadeMode.Stop)
           .MustAsync(async (identityNumber, _) => !await userService.ExistsWithIdentityNumberAsync(identityNumber!))
               .WithMessage((_, identityNumber) => string.Format(localizer["Identity number {0} is already registered."], identityNumber))
               .Unless(u => string.IsNullOrWhiteSpace(u.IdentityNumber));*/

        RuleFor(p => p.FullName).Cascade(CascadeMode.Stop)
            .NotEmpty();

        RuleFor(p => p.Password).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(p => p.ConfirmPassword).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Equal(p => p.Password);
    }
}