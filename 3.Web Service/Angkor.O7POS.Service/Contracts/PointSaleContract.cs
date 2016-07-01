using System.Collections.Generic;
using System.ServiceModel;
using Angkor.O7POS.Common.Entities;

namespace Angkor.O7POS.Service.Contracts
{
    [ServiceContract]
    public interface PointSaleContract
    {
        [OperationContract]
        List<SaleLocal> FindLocals (string companyId, string branchId);
    }
}