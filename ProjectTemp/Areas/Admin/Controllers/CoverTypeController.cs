using BookLelo.DataAccess.Data;
using BookLelo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLelo.Areas.Admin.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly ApplicationDbContext _Context;

        public CoverTypeController(ApplicationDbContext context)
        {
            _Context = context;
        }

        // GET: CatagoryController
        public IActionResult Index()
        {
            IEnumerable<CoverType> CoverTypeList = _Context.CoverType.ToList();
            return View(CoverTypeList);
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
        public IActionResult Create(CoverType CoverType)
        {

            _Context.CoverType.Add(CoverType);
            _Context.SaveChanges();
            TempData["Success"] = "Catagory Added SuccessFully";
            return RedirectToAction("Index");
        }

        // GET: CatagoryController/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null && id == 0)
                return NotFound();
            var data = _Context.CoverType.Find(id);
            if (data == null)
                return View(data);
            return View(data);
        }

        // POST: CatagoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType CoverType)
        {

            _Context.CoverType.Update(CoverType);
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
            var CoverTypeFromDb = _Context.CoverType.Find(id);
            if (CoverTypeFromDb == null)
            {
                NotFound();
            }
            return View(CoverTypeFromDb);
        }

        // POST: CatagoryController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _Context.CoverType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _Context.CoverType.Remove(obj);
            _Context.SaveChanges();
            TempData["Success"] = "Catagory Deleted SuccessFully";
            return RedirectToAction("Index");
        }
    }
}
