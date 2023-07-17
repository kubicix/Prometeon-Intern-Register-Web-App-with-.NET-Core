using System;
using System.Collections.Generic;

namespace StajBasvuru2.Models
{
    public partial class BasvuruReferans
    {
        public string Tcno { get; set; } = null!;
        public bool Calisanakraba { get; set; }
        public string? Yakinlikderecesi { get; set; }
        public string? Referansadsoyad { get; set; }
        public string? Referanstelefon { get; set; }
        public string? Referansemail { get; set; }
        public string? Referansbolum { get; set; }
        public string? Ekstrabilgi { get; set; }

        public virtual BasvuruKisisel TcnoNavigation { get; set; } = null!;
    }
}
