using CarouselSlider_Demo.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarouselSlider_Demo.Controllers
{
    public class ImageSliderController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [Route("List")]
        [ActionName("List")]
        public ActionResult Index()
        {
            var slider = db.ImageSliders.ToList();
            return View(slider);
        }

        [Route("{id}")]
        public ActionResult Details(int id)
        {
            var slider = db.ImageSliders.Find(id);
            return View(slider);
        }

        [Route("New")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("New")]
        public ActionResult New(HttpPostedFileBase FileUpload)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(FileUpload.FileName);
                string filePath = "~/Uploads/" + fileName;
                FileUpload.SaveAs(Server.MapPath(filePath));

                db.ImageSliders.Add(new ImageSlider
                {

                    ImageName = fileName,
                    ImagePath = filePath
                });
                db.SaveChanges();
                return RedirectToAction("List", "ImageSlider");
            }
            return View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var slider = db.ImageSliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public ActionResult Edit(ImageSlider imageSlider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List", "ImageSlider");
            }
            return View();
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var slider = db.ImageSliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]

        public ActionResult ConfirmDelete(int id)
        {
            var slider = db.ImageSliders.Find(id);
            db.ImageSliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("List", "ImageSlider");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}