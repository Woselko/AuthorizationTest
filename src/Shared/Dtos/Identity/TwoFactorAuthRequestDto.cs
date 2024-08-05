﻿namespace Test.Shared.Dtos.Identity;

public class TwoFactorAuthRequestDto
{
    public bool? Enable { get; init; }

    public string? TwoFactorCode { get; init; }

    public bool ResetSharedKey { get; init; }

    public bool ResetRecoveryCodes { get; init; }

    //public bool ForgetMachine { get; init; }
}
