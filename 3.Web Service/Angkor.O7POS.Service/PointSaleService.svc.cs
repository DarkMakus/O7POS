using System.Collections.Generic;
using Angkor.O7POS.Common.Entities;
using Angkor.O7POS.Domain;
using Angkor.O7POS.Service.Contracts;

namespace Angkor.O7POS.Service
{
    public class PointSaleService : PointSaleContract
    {
        public List<SaleLocal> FindLocals (string companyId, string branchId)
            => DomainManager.Instance.PointSaleDomain.FindLocals (companyId, branchId);
    }
}