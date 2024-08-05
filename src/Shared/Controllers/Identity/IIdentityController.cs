﻿using Test.Shared.Dtos.Identity;

namespace Test.Shared.Controllers.Identity;

[Route("api/[controller]/[action]/")]
public interface IIdentityController : IAppController
{
    [HttpPost]
    Task SendConfirmEmailToken(SendEmailTokenRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task ConfirmEmail(ConfirmEmailRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task SendConfirmPhoneToken(SendPhoneTokenRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task ConfirmPhone(ConfirmPhoneRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task SendResetPasswordToken(SendResetPasswordTokenRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task ResetPassword(ResetPasswordRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task<TokenResponseDto> Refresh(RefreshRequestDto request, CancellationToken cancellationToken) => default!;

    [HttpPost]
    [NoRetryPolicy] // Please note that retrying requests with Google reCaptcha will not work, as the Google verification mechanism only accepts a captcha response once.
    Task SignUp(SignUpRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task<SignInResponseDto> SignIn(SignInRequestDto request, CancellationToken cancellationToken) => default!;

    [HttpPost]
    Task SendTwoFactorToken(IdentityRequestDto request, CancellationToken cancellationToken);

    [HttpPost("{?returnUrl}")]
    Task SendOtp(IdentityRequestDto request, string? returnUrl = null, CancellationToken cancellationToken = default);

    [HttpGet("{?provider,returnUrl,localHttpPort}")]
    Task<string> GetSocialSignInUri(string provider, string? returnUrl = null, int? localHttpPort = null, CancellationToken cancellationToken = default);
}
