using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace StajBasvuru2.Models
{
    public class BigViewModel
    {

        public BasvuruKisisel Kisisel { get; set; } = new BasvuruKisisel();
        public BasvuruOkul Okul { get; set; } = new BasvuruOkul();
        public BasvuruReferans Referans { get; set; } = new BasvuruReferans();
        public BasvuruStajbilgi Staj { get; set; } = new BasvuruStajbilgi();
        
    }

}
