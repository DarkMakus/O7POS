using System;
using System.Linq;
using System.Web.Security;
using Angkor.O7Framework.ServiceClient.SecurityClient;
using Angkor.O7Framework.Web;
using Angkor.O7Framework.Web.Serializable;
using Angkor.O7POS.Model.Authentication;
using Newtonsoft.Json;

namespace Angkor.O7POS.Controller
{
    public partial class AuthenticationController : O7Controller
    {
        private O7UserSerializable BuildO7UserSerializable (LogInViewModel model)
        {
            return new O7UserSerializable
            {
                NickName = model.NickName,
                Password = model.Password,
                O7CompanySerializable = BuildO7CompanySerializable (model.Company),
                BranchSerializable = BuildO7BranchSerializable (model.Branch)
            };
        }
        private O7CompanySerializable BuildO7CompanySerializable (Company company)
        {
            return new O7CompanySerializable
            {
                Id = company.Id,
                Description = company.Description,
                O7BranchSerializables = company.Branches.Select (BuildO7BranchSerializable).ToArray ( )
            };
        }
        private O7BranchSerializable BuildO7BranchSerializable (Branch branch)
        {
            return new O7BranchSerializable {Id = branch.Id, Description = branch.Description};
        }
        private string BuildEncryptedTicket (O7UserSerializable o7UserSerializable)
        {
            string serializedUser = JsonConvert.SerializeObject (o7UserSerializable);
            var ticket = new FormsAuthenticationTicket (1, o7UserSerializable.NickName, DateTime.Now, DateTime.Now.AddMinutes (15), false,
                serializedUser);
            return FormsAuthentication.Encrypt (ticket);
        }
    }
}