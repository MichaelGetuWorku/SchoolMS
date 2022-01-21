using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolMSMVC.Models;
using System.Net.Http;

namespace SchoolMSMVC.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class LecturerController : Controller
    {
        // GET: Lecturer
        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<LecturersModal> lecturerList;
            HttpResponseMessage response = GlobalApiConnection.WebApitClient.GetAsync("LecturersApi").Result;
            lecturerList = response.Content.ReadAsAsync<IEnumerable<LecturersModal>>().Result;
            return View(lecturerList);
        }

        public ActionResult AddorEditLecturer(int id = 0)
        {
            if (id == 0)
            {
                return View(new LecturersModal());
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.GetAsync("LecturersApi/" + id.ToString()).Result;
                return View(responseMessage.Content.ReadAsAsync<LecturersModal>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEditLecturer(LecturersModal lecturers)
        {
            if (lecturers.Id == 0)
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.PostAsJsonAsync("LecturersApi", lecturers).Result;

                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.PutAsJsonAsync("LecturersApi/" + lecturers.Id, lecturers).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return View(new LecturersModal());
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.GetAsync("LecturersApi/" + id.ToString()).Result;
                return View(responseMessage.Content.ReadAsAsync<LecturersModal>().Result);
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.DeleteAsync("LecturersApi/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}