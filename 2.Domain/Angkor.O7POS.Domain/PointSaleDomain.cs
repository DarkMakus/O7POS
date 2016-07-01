using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Angkor.O7POS.Common.Entities;
using Angkor.O7POS.Data;
using Angkor.O7POS.Data.Oracle;
using Angkor.O7POS.Data.Provider;

namespace Angkor.O7POS.Domain
{
    public class PointSaleDomain
    {
        private string _connection;

        public PointSaleDomain ( )
        {
            _connection = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
        }

        public List<SaleLocal> FindLocals (string companyId, string branchId)
        {
            using (PointSaleProvider provider =new PointSaleOracleProvider (_connection))
            {
                List<AMLOCAL> result = provider.FindLocals (companyId, branchId);
                return result.Select (SetSaleLocal).ToList ( );
            }
        }

        private SaleLocal SetSaleLocal (AMLOCAL amlocal)
            => new SaleLocal {Id = amlocal.LOCCODLOC, Name = amlocal.LOCNOMBRE, Address = amlocal.LOCDIRECC};
    }
}