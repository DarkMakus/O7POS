using System.Collections.Generic;
using System.Linq;
using Angkor.O7POS.Data.Provider;

namespace Angkor.O7POS.Data.Oracle
{
    public class PointSaleOracleProvider : PointSaleProvider
    {
        private readonly PointSaleContext _context;

        public PointSaleOracleProvider (string connection)
        {
            _context = new PointSaleContext (connection);
        }

        public List<AMLOCAL> FindLocals (string companyId, string branchId)
        {
            IQueryable<AMLOCAL> locals =    from local in _context.AMLOCALs
                                            where local.LOCCODCIA == companyId && local.LOCCODSUC == branchId
                                            select local;
            return locals.ToList ( );
        }

        public void Dispose ( )
        {
            _context.Dispose ( );
        }
    }
}