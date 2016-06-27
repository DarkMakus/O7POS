using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Angkor.O7Framework.ServiceClient.SecurityClient;
using Angkor.O7Framework.Web;
using Angkor.O7Framework.Web.Serializable;
using Newtonsoft.Json;

namespace Angkor.O7POS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest (Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt (authCookie.Value);
                var serializeModel = JsonConvert.DeserializeObject <O7UserSerializable> (authTicket.UserData);
                var newUser = new O7User (serializeModel.NickName, serializeModel.Password, "Prueba", new Company (  ) {Id = serializeModel.O7CompanySerializable.Id}, new Branch { Id = serializeModel.BranchSerializable.Id, Description = serializeModel.BranchSerializable.Description});
                HttpContext.Current.User = newUser;
            }
        }
    }
}
