using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Models.DTO.Account
{
    public class CustomAuthorize:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                // yetkili olduğu sayfada ise herhangi bir değişiklik yapılmaz
                // yetkili olduğu sayfaya direkt girebilir.
                base.OnAuthorization(filterContext);
            }
            else
            {
                // yetkili değilse ya yetkili olduğu sayfaya geri gönderilir,
                // yada yetkisiz olduğuna dair error page i istemciye gönderilir.
                var _urlReferrer = filterContext.HttpContext.Request.UrlReferrer;

                if (_urlReferrer != null)
                {
                    string _redirectUrl = "~" + _urlReferrer.LocalPath;
                    filterContext.Result = new RedirectResult(_redirectUrl);
                }
                else
                {
                    // direkt url den talebi göndermiş demektir.
                    filterContext.Result = new RedirectResult("~/Account/NoAccess");
                }
            }
        }


        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;

            var customErrors = (CustomErrorsSection)ConfigurationManager.GetSection("system.web/customErrors");

            var accessDeniedPath = "";
            if (application.Response.StatusCode == 404)
            {
                accessDeniedPath = customErrors.Errors["404"] != null ? customErrors.Errors["404"].Redirect : customErrors.DefaultRedirect;
            }

            if (string.IsNullOrEmpty(accessDeniedPath))
            {
                return;
            }

            application.Response.ClearContent();
            application.Server.MapPath(accessDeniedPath);
            application.Response.Redirect(accessDeniedPath);
        }
    }
}