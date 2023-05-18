using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore6WebAdminLte2.Models;
using System.Data;

namespace NetCore6WebAdminLte2.Controllers
{
    [Authorize(Roles = "member,admin")]
    public class OgrenciTableController : Controller
    {

        private readonly OgrenciContext _context;
        public OgrenciTableController(OgrenciContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            OgrenciTable ogrenciTable = new OgrenciTable();
            return View(ogrenciTable);
        }
        [HttpPost]
        public IActionResult Create(OgrenciTable model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.OgrenciTable.Add(model);
                    _context.SaveChanges();
                    //TempData["Statu"] = "FirmaTipi Başarıyla Eklendi.";

                    return RedirectToAction("List");
                }
            }
            catch (Exception)
            {
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            //  OgrenciTable ogrenciTable = new OgrenciTable();
            try
            {
                var model = _context.OgrenciTable.Find(id);
                return View(model);

            }
            catch (Exception)
            {
            }
            return View(new OgrenciTable());
        }




        [HttpPost]
        public IActionResult Update(OgrenciTable model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.OgrenciTable.Update(model);
                    _context.SaveChanges();

                    return RedirectToAction("List");
                }
            }
            catch (Exception)
            {
            }
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _context.OgrenciTable.Find(id);
                if (model == null)
                {
                    return View();
                }
                _context.OgrenciTable.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception)
            {
            }
            return View();
        }


        public IActionResult List()
        {
            List<OgrenciTable> ogrenciTable = new List<OgrenciTable>();
            try
            {
                ogrenciTable = _context.OgrenciTable.ToList();
            }
            catch (Exception)
            {
            }
            return View(ogrenciTable);
        }
    }
}

