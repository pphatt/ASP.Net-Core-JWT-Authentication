using Server.Domain.Entity.Identity;

namespace Server.Application.Services.Authentication;

public record AuthenticationResult(AppUsers user, string AccessToken);
