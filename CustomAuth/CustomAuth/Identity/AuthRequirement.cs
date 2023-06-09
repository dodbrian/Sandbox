using Microsoft.AspNetCore.Authorization;

namespace CustomAuth.Identity;

public record AuthRequirement(SimplePolicy Policy) : IAuthorizationRequirement;
