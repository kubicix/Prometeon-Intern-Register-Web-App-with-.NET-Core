using System;
using System.Collections.Generic;

namespace StajBasvuru2.Models
{
    public partial class BasvuruStajbilgi
    {
        public string Tcno { get; set; } = null!;
        public bool Zorunlustaj { get; set; }
        public string Stajtur { get; set; } = null!;
        public int Stajsure { get; set; }
        public string Stajsuretipi { get; set; } = null!;
        public string Stajdonem { get; set; } = null!;
        public bool Stajyaptimi { get; set; }

        public virtual BasvuruKisisel TcnoNavigation { get; set; } = null!;
    }
}
