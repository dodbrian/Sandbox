using System.Reflection;
using CustomAuth.Identity.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomAuth.Identity.Filters;

public class SemanticAuthorizationActionFilter : IAsyncActionFilter
{
    private readonly IAuthorizationService _authorizationService;

    public SemanticAuthorizationActionFilter(IAuthorizationService authorizationService) =>
        _authorizationService = authorizationService;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var policyAttribute = context.ActionDescriptor.EndpointMetadata.OfType<PolicyAttribute>().FirstOrDefault();
        if (policyAttribute is not null)
        {
            var actionConditions = MapActionConditions(context);
            var policyName = policyAttribute.Policy;
            var result = await _authorizationService.AuthorizeAsync(
                context.HttpContext.User,
                actionConditions,
                policyName);

            if (!result.Succeeded)
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        await next();
    }

    private static Dictionary<string, (string argumentName, object? argumentValue)> MapActionConditions(
        ActionExecutingContext context)
    {
        var mapping = new Dictionary<string, (string, object?)>();
        if (context.ActionDescriptor is not ControllerActionDescriptor controllerActionDescriptor) return mapping;

        var methodInfo = controllerActionDescriptor.MethodInfo;
        foreach (var parameter in methodInfo.GetParameters())
        {
            var conditionAttribute = parameter.GetCustomAttribute<ConditionAttribute>();
            if (conditionAttribute is null) continue;

            var conditionName = conditionAttribute.ConditionName;
            var argumentName = parameter.Name!;
            var argumentValue = context.ActionArguments[argumentName];
            mapping[conditionName] = (argumentName, argumentValue);
        }

        return mapping;
    }
}
