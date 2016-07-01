using System.Data.Entity;

namespace Angkor.O7POS.Data
{
    public class PointSaleContext : DbContext
    {
        public PointSaleContext (string connection) : base (connection)
        {
        }

        public virtual DbSet<AMLOCAL> AMLOCALs { get; set; }

        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCCODCIA).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCCODSUC).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCCODLOC).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCDIRECC).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCNOMBRE).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCALMACE).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCALMABA).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCCODCCO).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCSERPRT).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCBANCO).IsFixedLength ( ).IsUnicode (false);

            modelBuilder.Entity<AMLOCAL> ( ).Property (e => e.LOCCTABCO).IsFixedLength ( ).IsUnicode (false);
        }
    }
}