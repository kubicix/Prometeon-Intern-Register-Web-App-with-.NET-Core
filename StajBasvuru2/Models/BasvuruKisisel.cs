using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StajBasvuru2.Models
{
    public partial class BasvuruKisisel
    {
        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        public string Adsoyad { get; set; } = null!;

        [Required(ErrorMessage = "TC No alanı zorunludur.")]
        public string Tcno { get; set; } = null!;

        [Required(ErrorMessage = "Telefon No alanı zorunludur.")]
        public string Telno { get; set; } = null!;

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; } = null!;
        public virtual BasvuruOkul? BasvuruOkul { get; set; }
        public virtual BasvuruReferans? BasvuruReferan { get; set; }
        public virtual BasvuruStajbilgi? BasvuruStajbilgi { get; set; }
    }
}
