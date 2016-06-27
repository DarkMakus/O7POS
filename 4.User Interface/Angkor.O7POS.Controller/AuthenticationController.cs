using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Angkor.O7Framework.ServiceClient.SecurityClient;
using Angkor.O7Framework.Web;
using Angkor.O7Framework.Web.Serializable;
using Angkor.O7POS.Model.Authentication;

namespace Angkor.O7POS.Controller
{
    public partial class AuthenticationController : O7Controller
    {
        public ActionResult LogIn ( )
        {
            return View ( );
        }

        [HttpPost] public JsonResult GetAccess (LogInViewModel model)
        {
            //List <Company> companies = CommonServiceClient.GetSecurityContract ( ).FindCredentials (model.NickName, model.Password);
            var companies = new List <Company>
            {
                new Company
                {
                    Id = "001",
                    Description = "Compania01",
                    Branches =
                        new List <Branch>
                        {
                            new Branch {Id = "001", Description = "Sucursal01"},
                            new Branch {Id = "002", Description = "Sucursal02"}
                        }
                },
                new Company
                {
                    Id = "002",
                    Description = "Compania02",
                    Branches =
                        new List <Branch>
                        {
                            new Branch {Id = "001", Description = "Sucursal01"},
                            new Branch {Id = "002", Description = "Sucursal02"}
                        }
                }
            };
            return Json (companies, JsonRequestBehavior.AllowGet);
        }

        [HttpPost] public ActionResult LogIn (LogInViewModel model)
        {
            O7UserSerializable serializeModel = BuildO7UserSerializable (model);
            string ticket = BuildEncryptedTicket (serializeModel);
            var cookie = new HttpCookie (FormsAuthentication.FormsCookieName, ticket);
            Response.Cookies.Add (cookie);
            return RedirectToAction ("RegisterProduct", "Sales");
        }
    }
}