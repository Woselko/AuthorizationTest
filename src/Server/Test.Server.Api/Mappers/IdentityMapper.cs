using Riok.Mapperly.Abstractions;
using Test.Server.Api.Models.Identity;
using Test.Shared.Dtos.Identity;

namespace Test.Server.Api.Mappers;

/// <summary>
/// More info at Server/Mappers/README.md
/// </summary>
[Mapper(UseDeepCloning = true)]
public static partial class IdentityMapper
{
    public static partial UserDto Map(this User source);
    public static partial void Patch(this EditUserDto source, User destination);

    // https://mapperly.riok.app/docs/configuration/before-after-map/
    public static partial UserSessionDto Map(this UserSession source);
}
