using System;
using System.Collections.Generic;

namespace StajBasvuru2.Models
{
    public partial class BasvuruOkul
    {
        public string Tcno { get; set; } = null!;
        public string Okultur { get; set; } = null!;
        public string Okulad { get; set; } = null!;
        public string Bolum { get; set; } = null!;
        public string Sınıf { get; set; } = null!;
        public decimal Ortalama { get; set; }
        public string Notsistem { get; set; } = null!;

        public virtual BasvuruKisisel TcnoNavigation { get; set; } = null!;
    }
}
