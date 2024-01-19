using Edukate.Areas.Admin.ViewModels.Instructor;
using Edukate.Context;
using Edukate.Helpers;
using Edukate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Edukate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController : Controller
    {
        public EdukateDbContext _db { get; set; }
        public InstructorController(EdukateDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<InstructorListItemVm> list = _db.Instructors.Select(x => new InstructorListItemVm
            {
                Id = x.Id,
                Name = x.Name,
                ImgUrl = x.ImgUrl,
                ProfessionName = x.Profession.Name
            });
            return View(list);
        }

        public IActionResult Create() 
        {
            ViewBag.Profession = new SelectList(_db.Professions.Where(x=> x.IsDeleted), "Name", "Id");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InstructorCreateVm create)
        {
            
            if(!ModelState.IsValid) 
            {
                ViewBag.Profession = new SelectList(_db.Professions.Where(x => x.IsDeleted), "Name", "Id");
                return View(create);
            }

            if(create.ImgUrl != null)
            {
                if (!create.ImgUrl.InValidType())
                {
                    ViewBag.Profession = new SelectList(_db.Professions.Where(x => x.IsDeleted), "Name", "Id");
                    ModelState.AddModelError("ImgUrl", "Wrong File");
                    return View(create);
                }
            }

            if(!_db.Professions.AnyAsync(x=> x.Id==create.ProfessionId).Result) return BadRequest();

            await _db.Instructors.AddAsync(new Instructor
            {
                ImgUrl = create.ImgUrl.SaveAsync(PathConstant.ImgPath).Result,
                Name = create.Name,
                Profession = create.Profession                                                
            });

            await _db.SaveChangesAsync();
            return RedirectToAction("Home", "Instructor");
        }


        public async Task<IActionResult> Update()
        {
            ViewBag.Profession = new SelectList(_db.Professions.Where(x => x.IsDeleted), "Name", "Id");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(InstructorUpdateVm create,int? id)
        {

            if (id == null || id < 1) return BadRequest();

            var item = _db.Instructors.FindAsync(id).Result;

            if (item == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Profession = new SelectList(_db.Professions.Where(x => x.IsDeleted), "Name", "Id");
                return View(create);
            }

            if (create.ImgUrl != null)
            {
                if (!create.ImgUrl.InValidType())
                {
                    ViewBag.Profession = new SelectList(_db.Professions.Where(x => x.IsDeleted), "Name", "Id");
                    ModelState.AddModelError("ImgUrl", "Wrong File");
                    return View(create);
                }
                item.ImgUrl = create.ImgUrl.SaveAsync(PathConstant.ImgPath).Result;
            }

            if (!_db.Professions.AnyAsync(x => x.Id == create.ProfessionId).Result) return BadRequest();
            
            item.Name = item.Name;
            item.ProfessionId = item.ProfessionId;
           
            await _db.SaveChangesAsync();
            return RedirectToAction("Home", "Instructor");
        }
    }
}
