using Models;

namespace MauiBlazor.Services;

internal class AuthorisationService : IAuthorisationService
{
    public AuthorisedUser AuthorisedUser { get; set; }

    public AuthorisationService()
    {
        AuthorisedUser = new AuthorisedUser("1", "N3vix", ["Server1", "Server2", "Server7"]);
    }
}
