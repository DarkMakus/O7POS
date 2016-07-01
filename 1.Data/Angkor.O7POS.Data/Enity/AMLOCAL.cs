namespace Angkor.O7POS.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AM01.AMLOCAL")]
    public partial class AMLOCAL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string LOCCODCIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string LOCCODSUC { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string LOCCODLOC { get; set; }

        [StringLength(60)]
        public string LOCDIRECC { get; set; }

        [StringLength(50)]
        public string LOCNOMBRE { get; set; }

        [StringLength(2)]
        public string LOCALMACE { get; set; }

        [StringLength(2)]
        public string LOCALMABA { get; set; }

        [StringLength(6)]
        public string LOCCODCCO { get; set; }

        public long LOCSECPVT { get; set; }

        public long LOCSECATM { get; set; }

        public long LOCSECIDM { get; set; }

        [StringLength(12)]
        public string LOCSERPRT { get; set; }

        [StringLength(3)]
        public string LOCBANCO { get; set; }

        [StringLength(8)]
        public string LOCCTABCO { get; set; }
    }
}
