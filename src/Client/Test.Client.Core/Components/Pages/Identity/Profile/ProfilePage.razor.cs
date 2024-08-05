using Test.Shared.Dtos.Identity;
using Test.Shared.Controllers.Identity;

namespace Test.Client.Core.Components.Pages.Identity.Profile;

[Authorize]
public partial class ProfilePage
{
    private UserDto? user;
    private bool isLoading;


    [AutoInject] private IUserController userController = default!;


    protected override async Task OnInitAsync()
    {
        isLoading = true;

        try
        {
            user = await userController.GetCurrentUser(CurrentCancellationToken);
        }
        finally
        {
            isLoading = false;
        }

        await base.OnInitAsync();
    }
}
