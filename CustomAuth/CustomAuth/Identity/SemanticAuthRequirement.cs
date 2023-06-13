using CustomAuth.Identity.PolicyModel;
using Microsoft.AspNetCore.Authorization;

namespace CustomAuth.Identity;

public record SemanticAuthRequirement(Policy Policy) : IAuthorizationRequirement;
