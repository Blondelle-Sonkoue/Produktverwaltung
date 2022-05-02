using Microsoft.AspNetCore.Mvc;
using Produktverwaltung.Models;
using Produktverwaltung.Persistence;

namespace Produktverwaltung.Controllers
{
    public class ProduktController : Controller
    {
        private readonly CDbContext _db;
        public ProduktController(CDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Produkt> ProduktList = _db.Produkts;
            return View(ProduktList);
        }
            //Get-Create
            public IActionResult Create()
            {
                 return View();
            }
            //Post-Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Produkt obj)
            {
              
                _db.Produkts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
             
            }
              
        //Get-Delete

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Produkts.Find(id);
            if (obj == null)
            {

                return NotFound();

            }
            return View("obj");
        }


        //Post-Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Produkts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Produkts.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        //Get-Update

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Produkts.Find(id);
            if (obj == null)
            {

                return NotFound();

            }
            return View("obj");
        }
        //Post-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Produkt obj)
        {
           
                _db.Produkts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }

    }
}
