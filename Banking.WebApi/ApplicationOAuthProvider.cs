using Banking.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Banking.WebApi
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                context.Validated(identity);
                var userRole = manager.GetRoles(user.Id);
                foreach (var rolename in userRole)
                {
                    identity.AddClaim(new Claim("Role", rolename));
                }
                var additionalData = new Microsoft.Owin.Security.AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "role",Newtonsoft.Json.JsonConvert.SerializeObject(userRole)
                    }


                }) ;
                var token = new AuthenticationTicket(identity, additionalData);
                context.Validated(token);
            }
            else
                return;
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach ( KeyValuePair<string,string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

    }
}