using System;
using System.Collections.Generic;

namespace Angkor.O7POS.Data.Provider
{
    public interface PointSaleProvider : IDisposable
    {
        List<AMLOCAL> FindLocals (string companyId, string branchId);
    }
}