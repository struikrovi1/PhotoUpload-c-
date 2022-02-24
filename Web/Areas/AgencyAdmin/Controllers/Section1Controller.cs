using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Web.Areas.AgencyAdmin.Controllers
{
    [Area(nameof(AgencyAdmin))]
    public class Section1Controller : Controller
    {
        private readonly Section1Service _context;
        private readonly IWebHostEnvironment _environment;
        public Section1Controller(Section1Service context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Section1Controller
        public async Task<ActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: Section1Controller/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if(!id.HasValue) return NotFound();
            var selectedSection = await _context.GetById(id);
            if(selectedSection ==null) return NotFound();
            return View(selectedSection);
        }

        // GET: Section1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Section1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Section1 section,IFormFile PhotoUrl)
        {
            try
            {
                //Secdiyin sekli wwwroot folderinin içərisində yaradır
                string filename=Guid.NewGuid()+PhotoUrl.FileName;
                string uploadRoot = Path.Combine(_environment.WebRootPath, "uploads");
                string fileRoot=Path.Combine(uploadRoot,filename);
                using FileStream stream = new FileStream(fileRoot, FileMode.Create);
                PhotoUrl.CopyTo(stream);

                //sqlə şəklin hansı adda yaradılacağını göstərir
                section.PhotoUrl = "/uploads/"+filename;
                
               // Add Section1 Data
                await _context.Add(section);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Section1Controller/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue) return NotFound();
            var selectedSection = await _context.GetById(id);
            if (selectedSection == null) return NotFound();
            return View(selectedSection);
        }

        // POST: Section1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Section1 section,IFormFile NewPhoto)
        {
            try
            {
                if (NewPhoto != null)
                {
                    //Əvvəlki şəkli folderdən silmək üçün
                    string fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    string rootPicture = fileDirectory + section.PhotoUrl;
                    if (System.IO.File.Exists(rootPicture))
                    {
                        System.IO.File.Delete(rootPicture);
                    }
                    //Secdiyin sekli wwwroot folderinin içərisində yaradır
                    string filename = Guid.NewGuid() + NewPhoto.FileName;
                    string uploadRoot = Path.Combine(_environment.WebRootPath, "uploads");
                    string fileRoot = Path.Combine(uploadRoot, filename);
                    using FileStream stream = new FileStream(fileRoot, FileMode.Create);
                    NewPhoto.CopyTo(stream);

                    //sqlə şəklin hansı adda yaradılacağını göstərir
                    section.PhotoUrl = "/uploads/" + filename;
                }

                await _context.Update(section);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Section1Controller/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue) return NotFound();
            return View();
        }

        // POST: Section1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _context.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
