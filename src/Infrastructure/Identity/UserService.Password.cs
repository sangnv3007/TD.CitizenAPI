using TD.CitizenAPI.Application.Common.Exceptions;
using TD.CitizenAPI.Application.Common.Mailing;
using TD.CitizenAPI.Application.Identity;
using TD.CitizenAPI.Application.Identity.Users.Password;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace TD.CitizenAPI.Infrastructure.Identity;

internal partial class UserService
{
    public async Task<string> ForgotPasswordAsync(ForgotPasswordRequest request, string origin)
    {
        EnsureValidTenant();


       if (string.IsNullOrWhiteSpace(request.Email) && string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            // Don't reveal that the user does not exist or is not confirmed
            throw new InternalServerException(_localizer["An Error has occurred!"]);
        }

        ApplicationUser? user = null;

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            /* var user_ = await _userInfoRepository.GetByPhoneNumberAsync(model.PhoneNumber);
             if (user == null) throw new ApiException($"No Accounts Registered with {model.PhoneNumber}.");
             account = await _userManager.FindByNameAsync(user.UserName);*/
            user = await _userManager.Users
            .AsNoTracking()
            .Where(u => u.PhoneNumber == request.PhoneNumber)
            .FirstOrDefaultAsync(default);
        }
        else
        {
            user = await _userManager.FindByEmailAsync(request.Email?.Normalize());
        }


        /*  // var user = await _userManager.FindByEmailAsync(request.Email.Normalize());
           if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
           {
               // Don't reveal that the user does not exist or is not confirmed
               throw new InternalServerException(_localizer["An Error has occurred!"]);
           }*/
        if (user is null )
        {
            // Don't reveal that the user does not exist or is not confirmed
            throw new InternalServerException(_localizer["An Error has occurred!"]);
        }


        // For more information on how to enable account confirmation and password reset please
        // visit https://go.microsoft.com/fwlink/?LinkID=532713
        string code = await _userManager.GeneratePasswordResetTokenAsync(user);


        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            /*TDSmsRequest tDSmsRequest = new TDSmsRequest()
            {
                NoiDungthamSo = code + ",5",
                SoDienThoai = model.PhoneNumber,
            };
            await _smsServices.SendAsync(tDSmsRequest);*/
            return _localizer["Mã xác thực đã được gửi tới số điện thoại của bạn! Vui lòng kiểm tra và làm theo hướng dẫn."];
        }
        else
        {
            const string route = "account/reset-password";
            var endpointUri = new Uri(string.Concat($"{origin}/", route));
            string passwordResetUrl = QueryHelpers.AddQueryString(endpointUri.ToString(), "Token", code);
            var mailRequest = new MailRequest(
                new List<string> {request.Email},
                _localizer["Đổi mật khẩu"],
                _localizer[$"Để đổi mật khẩu, vui lòng sử dụng Mật khẩu dùng một lần (OTP) sau: '{code}'. Không chia sẻ OTP này với bất kỳ ai. Nhóm dịch vụ khách hàng của chúng tôi sẽ không bao giờ yêu cầu bạn cung cấp mật khẩu, OTP, thẻ tín dụng hoặc thông tin ngân hàng của bạn. Bạn có thể đổi mật khẩu qua đường dẫn {endpointUri}."]);
            _jobService.Enqueue(() => _mailService.SendAsync(mailRequest, CancellationToken.None));

            return _localizer["Mã xác thực đã được gửi tới email của bạn! Vui lòng kiểm tra và làm theo hướng dẫn."];
        }

    }

    public async Task<string> ResetPasswordAsync(ResetPasswordRequest request)
    {

        if (string.IsNullOrWhiteSpace(request.Email) && string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            throw new InternalServerException(_localizer["An Error has occurred!"]);
        }

        ApplicationUser? user = null;

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            user = await _userManager.Users
            .AsNoTracking()
            .Where(u => u.PhoneNumber == request.PhoneNumber)
            .FirstOrDefaultAsync(default);
        }
        else
        {
            user = await _userManager.FindByEmailAsync(request.Email?.Normalize());
        }

        //var user = await _userManager.FindByEmailAsync(request.Email?.Normalize());

        // Don't reveal that the user does not exist
        _ = user ?? throw new InternalServerException(_localizer["An Error has occurred!"]);

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);

        return result.Succeeded
            ? _localizer["Password Reset Successful!"]
            : throw new InternalServerException(_localizer["An Error has occurred!"]);
    }

    public async Task ChangePasswordAsync(ChangePasswordRequest model, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        _ = user ?? throw new NotFoundException(_localizer["User Not Found."]);

        var result = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);

        if (!result.Succeeded)
        {
            throw new InternalServerException(_localizer["Change password failed"], result.GetErrors(_localizer));
        }
    }
}