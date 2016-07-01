using Angkor.O7POS.Common.ServiceClient.PointSaleReference;

namespace Angkor.O7POS.Common.ServiceClient
{
    public class O7POSServiceClient
    {
        public static PointSaleContract PointSaleContract
            => new PointSaleContractClient ( );
    }
}
