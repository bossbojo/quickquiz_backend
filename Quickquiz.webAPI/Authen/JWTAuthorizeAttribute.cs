
namespace Quickquiz.webAPI.Authen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using Quickquiz.webAPI.Entity;

    public class JWTAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
        
            string token = HttpContext.Current.Request.Headers["Authorization"];
            if (token != null)
            {
                try
                {
                    Authentication decodeToken = Securities.JWTDecode<Authentication>(token);
                    if (Authentication.HasToken(decodeToken))
                    {
                        var users = new quickquizDB().Users.Where(c => c.username.Equals(decodeToken.username)).FirstOrDefault();
                        if (users != null)
                        {
                            Authentication.SetAuthenticated(users);
                            return;
                        }
                    }
                    else
                    {
                        Authentication.SetAuthenticated(username: null,firstname:null,lastname:null,status:0);
                    }
                }
                catch
                { }
            }
            base.OnAuthorization(actionContext);
        }
    }
}