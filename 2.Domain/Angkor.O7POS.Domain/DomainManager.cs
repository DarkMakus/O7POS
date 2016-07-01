namespace Angkor.O7POS.Domain
{
    public class DomainManager
    {
        private static DomainManager _current;

        private DomainManager ( )
        {
        }

        public static DomainManager Instance 
            => _current ?? (_current = new DomainManager ( ));

        public PointSaleDomain PointSaleDomain
            => new PointSaleDomain ( );

    }
}