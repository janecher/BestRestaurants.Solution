using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public CuisinesController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
        foreach(Cuisine cus in _db.Cuisines)
        {
          if(cus.Type == cuisine.Type)
          {
            return RedirectToAction("Index");
          }
        }
        _db.Cuisines.Add(cuisine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Cuisine thisCuisine = _db.Cuisines.Include(cuisine => cuisine.Restaurants).FirstOrDefault(cuisines => cuisines.CuisineId == id);
        return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
        return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
        _db.Entry(cuisine).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
        return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
        _db.Cuisines.Remove(thisCuisine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}