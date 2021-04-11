using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace proxy
{
    internal class CustomAuthorizationPolicy : AuthorizationPolicy
    {
        public CustomAuthorizationPolicy(IEnumerable<IAuthorizationRequirement> requirements, IEnumerable<string> authenticationSchemes) : base(requirements, authenticationSchemes)
        {
        }
    }
}