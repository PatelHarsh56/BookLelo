using BookLelo.DataAccess.Data;
using BookLelo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLelo.Areas.Admin.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public CatagoryController(ApplicationDbContext context)
        {
            _Context = context;
        }

        // GET: CatagoryController
        public IActionResult Index()
        {
            IEnumerable<Catagory> CatagoryList = _Context.Catagories.ToList();
            return View(CatagoryList);
        }

        // GET: CatagoryController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CatagoryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatagoryController/Create
        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {
            if (catagory.Name == catagory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Error", "Name And Dispaly Order Cannot Be Same");
            }
            _Context.Catagories.Add(catagory);
            _Context.SaveChanges();
            TempData["Success"] = "Catagory Added SuccessFully";
            return RedirectToAction("Index");
        }

        // GET: CatagoryController/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null && id == 0)
                return NotFound();
            var data = _Context.Catagories.Find(id);
            if (data == null)
                return View(data);
            return View(data);
        }

        // POST: CatagoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory catagory)
        {
            if (catagory.Name == catagory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Error", "Name And Dispaly Order Cannot Be Same");
            }
            _Context.Catagories.Update(catagory);
            _Context.SaveChanges();
            TempData["Success"] = "Catagory Updated SuccessFully";
            return RedirectToAction("Index");
        }

        // GET: CatagoryController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _Context.Catagories.Find(id);
            if (catagoryFromDb == null)
            {
                NotFound();
            }
            return View(catagoryFromDb);
        }

        // POST: CatagoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _Context.Catagories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _Context.Catagories.Remove(obj);
            _Context.SaveChanges();
            TempData["Success"] = "Catagory Deleted SuccessFully";
            return RedirectToAction("Index");
        }
    }
}
