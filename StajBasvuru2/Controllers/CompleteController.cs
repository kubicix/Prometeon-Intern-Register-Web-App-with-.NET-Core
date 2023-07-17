using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StajBasvuru2.Models;

namespace StajBasvuru2.Controllers
{
    public class CompleteController : Controller
    {
        private readonly INTERNContext _context;

        public CompleteController(INTERNContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BigViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Kisisel.Adsoyad", "Bu alan boş bırakılamaz.");
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    // Hata işleme veya loglama yapmak için burada error değerini kullanabilirsiniz
                    // Örnek olarak, hataları konsola yazdıralım:
                    Console.WriteLine(error);
                }
            }
            // TC Kimlik numarasının sistemde kayıtlı olup olmadığını kontrol etme
            var existingUser = await _context.BasvuruKisisels.FirstOrDefaultAsync(u => u.Tcno == viewModel.Kisisel.Tcno);
            if (existingUser != null)
            {
                ModelState.AddModelError("Kisisel.Tcno", "Bu TC Kimlik numarası zaten kayıtlıdır.");
                TempData["ErrorMessage"] = "Bu TC Kimlik numarası zaten kayıtlıdır.";
                // Hata durumunda Create view'ını tekrar göster
                return RedirectToAction("Index", "Home");
            }

            var basvuruKisisel = new BasvuruKisisel
            {
                Adsoyad = viewModel.Kisisel.Adsoyad,
                Tcno = viewModel.Kisisel.Tcno,
                Telno = viewModel.Kisisel.Telno,
                Email = viewModel.Kisisel.Email
            };

            var basvuruOkul = new BasvuruOkul
            {
                Tcno = viewModel.Kisisel.Tcno,
                Okultur = viewModel.Okul.Okultur,
                Okulad = viewModel.Okul.Okulad,
                Bolum = viewModel.Okul.Bolum,
                Sınıf = viewModel.Okul.Sınıf,
                Ortalama = viewModel.Okul.Ortalama,
                Notsistem = viewModel.Okul.Notsistem
            };

            var basvuruStajbilgi = new BasvuruStajbilgi
            {
                Tcno = viewModel.Kisisel.Tcno,
                Zorunlustaj = viewModel.Staj.Zorunlustaj,
                Stajtur = viewModel.Staj.Stajtur,
                Stajsure = viewModel.Staj.Stajsure,
                Stajsuretipi = viewModel.Staj.Stajsuretipi,
                Stajdonem = viewModel.Staj.Stajdonem,
                Stajyaptimi = viewModel.Staj.Stajyaptimi
            };

            var basvuruReferans = new BasvuruReferans
            {
                Tcno = viewModel.Kisisel.Tcno,
                Calisanakraba = viewModel.Referans.Calisanakraba,
                Yakinlikderecesi = viewModel.Referans.Yakinlikderecesi,
                Referansadsoyad = viewModel.Referans.Referansadsoyad,
                Referanstelefon = viewModel.Referans.Referanstelefon,
                Referansemail = viewModel.Referans.Referansemail,
                Referansbolum = viewModel.Referans.Referansbolum,
                Ekstrabilgi = viewModel.Referans.Ekstrabilgi
            };

            _context.BasvuruKisisels.Add(basvuruKisisel);
            _context.BasvuruOkuls.Add(basvuruOkul);
            _context.BasvuruStajbilgis.Add(basvuruStajbilgi);
            _context.BasvuruReferans.Add(basvuruReferans);

            await _context.SaveChangesAsync();

            return PartialView("~/Views/Complete/Kaydet.cshtml");
        }
        
        

    }
}
