using EntityFremworkApp.Data;
using EntityFremworkApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFremworkApp.Controllers
{
  public class KursController : Controller
  {
    private readonly DataContext _context;

    public KursController(DataContext context)
    {
      _context = context;
    }


    public async Task<IActionResult> Index()
    {
      var Kurslar = await _context.Kurslar.Include(k => k.Ogretmen).ToListAsync();
      return View(Kurslar);
    }

    public async Task<IActionResult> Create()
    {
      ViewBag.ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Kurs model)
    {
      _context.Kurslar.Add(model);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }




    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        //404 hata kodu gönderilir
        return NotFound();
      }


      // veritabınında böyle bir Id yoksa 404 hatası gönderir
      var kurs = await _context
                      .Kurslar
                      .Include(k => k.KursKayitleri)
                      .ThenInclude(k => k.Ogrenci)
                      .Select(k => new KursViewModel{
                        KursId=k.KursId,
                        Baslik=k.Baslik,
                        OgretmenId=k.OgretmenId,
                        KursKayitleri=k.KursKayitleri
                      })
                      .FirstOrDefaultAsync(k => k.KursId == id);

      if (kurs == null)
      {
        return NotFound();
      }

      ViewBag.ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");


      return View(kurs);

    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, KursViewModel model)
    {
      if (id != model.KursId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(new Kurs() { KursId = model.KursId, Baslik = model.Baslik, OgretmenId = model.OgretmenId });
          //Günceleme kısmı burda olur
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!_context.Kurslar.Any(o => o.KursId == model.KursId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction("Index");
      }

      return View(model);
    }





    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var kurs = await _context.Kurslar.FindAsync(id);

      if (kurs == null)
      {
        return NotFound();
      }

      return View(kurs);
    }

    [HttpPost]

    //form içerisindeki ıd aliyor
    public async Task<IActionResult> Delete([FromForm] int id)
    {
      var kurs = await _context.Kurslar.FindAsync(id);
      if (kurs == null)
      {
        return NotFound();
      }
      _context.Kurslar.Remove(kurs);
      await _context.SaveChangesAsync();

      return RedirectToAction("Index");
    }

  }
}