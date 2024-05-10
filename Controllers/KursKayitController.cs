using EntityFremworkApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFremworkApp.Controllers
{
  public class KursKayitController : Controller
  {
    private readonly DataContext _context;
    public KursKayitController(DataContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Create()
    {
      ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");
      ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(KursKayit model)
    {
      model.KayitTarihi = DateTime.Now;
      _context.KursKayitleri.Add(model);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }


    public async Task<IActionResult> Index()
    {
      var KursKayitleri = await _context.KursKayitleri
      .Include(x => x.Ogrenci)
      .Include(x => x.Kurs)
      .ToListAsync();
      return View(KursKayitleri);
    }
  }


}


