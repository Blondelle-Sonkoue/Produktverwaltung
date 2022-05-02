using Microsoft.AspNetCore.Mvc;
using Produktverwaltung.Models;
using Produktverwaltung.Persistence;
using System.Collections.Generic;

public class CategoryController : Controller
    {
    private readonly CDbContext _db;
    public CategoryController(CDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
        {
        IEnumerable<Category> categoryList = _db.Categories;
            return View(categoryList);
        }
    //Get-Create
    public IActionResult Create()
    {
        
        return View();
    }
    //Post-Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {

        

            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        return View(obj);
    }

    //Get-Delete

    public IActionResult Delete(int? id)
    {

        if (id == null || id == 0)
        {
            return NotFound();
        }
        var obj = _db.Categories.Find(id);
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
        var obj = _db.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(obj);
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
        var obj = _db.Categories.Find(id);
        if (obj == null)
        {

            return NotFound();

        }
        return View("obj");
    }
    //Post-Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Category obj)
    {

            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        
    }
}



