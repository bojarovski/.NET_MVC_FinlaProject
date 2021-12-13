using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BrandsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Brands> objList = _db.Brands;
            return View(objList);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brands obj)
        {
            if (ModelState.IsValid)
            {
                _db.Brands.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        //GET EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Brands.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Brands obj)
        {
            if (ModelState.IsValid)
            {
                _db.Brands.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }
        //GET DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Brands.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConf(int? id)
        {
            var obj = _db.Brands.Find(id);
            
                _db.Brands.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
