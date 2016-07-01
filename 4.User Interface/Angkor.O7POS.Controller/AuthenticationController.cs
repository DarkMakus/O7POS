using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Angkor.O7Framework.ServiceClient;
using Angkor.O7Framework.ServiceClient.SecurityClient;
using Angkor.O7Framework.Web;
using Angkor.O7Framework.Web.Serializable;
using Angkor.O7POS.Model.Authentication;
using Angkor.O7POS.Common.ServiceClient;
using Angkor.O7POS.Common.ServiceClient.PointSaleReference;

namespace Angkor.O7POS.Controller
{
    public partial class AuthenticationController : O7Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAccess(LogInViewModel model)
        {
            List<Company> credentials = CommonServiceClient.GetSecurityContract().FindCredentials(model.NickName, model.Password);

            var credential = new List<dynamic>();

            foreach (Company company in credentials)
            {
                List<dynamic> branches = new List<dynamic>();
                foreach (Branch branch in company.Branches)
                {
                    List<SaleLocal> points = O7POSServiceClient.PointSaleContract.FindLocals(company.Id, branch.Id);
                    var pointSales = new List<dynamic>();
                    foreach (SaleLocal locales in points)
                    {
                        pointSales.Add(new { locales.Id, locales.Name, locales.Address });
                    }
                    dynamic bran = new { branch.Id, branch.Description, PointSales = pointSales.ToArray() };
                    branches.Add(bran);
                }
                dynamic comp = new { company.Id, company.Description, Branches = branches.ToArray() };
                credential.Add(comp);
            }

            return Json(credential.ToArray(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            O7UserSerializable serializeModel = BuildO7UserSerializable(model);
            string ticket = BuildEncryptedTicket(serializeModel);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticket);
            Response.Cookies.Add(cookie);
            return RedirectToAction("RegisterProduct", "Sales");
        }
    }
}