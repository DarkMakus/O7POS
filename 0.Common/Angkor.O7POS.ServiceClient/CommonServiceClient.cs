using Angkor.O7POS.ServiceClient.SecurityReference;

namespace Angkor.O7POS.ServiceClient
{
    public class CommonServiceClient
    {
        public static SecurityContract GetSecurityContract ( )
        {
            return new SecurityContractClient();
        }
    }
}