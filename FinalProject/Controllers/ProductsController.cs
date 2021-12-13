using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> objList = _db.Products;
            foreach(var obj in objList)
            {
                obj.Brands = _db.Brands.FirstOrDefault(u => u.Id == obj.BrandId);//
            }
            return View(objList);
        }



        //GET Upsert
        public IActionResult Upsert(int? id) // Kako ke se prikaze View to 
        {
            //kako brend go prosleduvame do view
            //IEnumerable<SelectListItem> BrandDropDown = _db.Brands.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});


            //ViewBag.List = BrandDropDown;
            //Products products = new Products();

            ProductVM productVM = new ProductVM()
            {
                Products = new Products(),
                DropDown = _db.Brands.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };
            

        
            if (id == null)
            {
                //this is for create
                return View(productVM);
            }
            else
            {
                //this is for edit
                productVM.Products = _db.Products.Find(id);
                if (productVM.Products == null)
                {
                    return NotFound();
                }

                return View(productVM);
            }

        }

        //POST Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(productVM productVM)
        {
            if (ModelState.IsValid)
            {
               
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
            var obj = _db.Products.Find(id);
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
            var obj = _db.Products.Find(id);

            _db.Products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


