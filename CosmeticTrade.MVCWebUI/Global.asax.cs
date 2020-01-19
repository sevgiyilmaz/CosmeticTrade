using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.MVCWebUI.Models.Cart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CosmeticTrade.MVCWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Session_Start(object sender, EventArgs e)
        {
            var cart = (CartModel)Session["Cart"];
            if (cart == null)
            {
                cart = new CartModel();
                Session["Cart"] = cart;
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        string username = HttpContext.Current.User.Identity.Name;
                        var ur = new UserRepository();
                        var roles = ur.RolesByUserName(username);
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(username, "Forms"), roles.ToArray());
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
