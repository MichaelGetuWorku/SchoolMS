using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SchoolMSMVC.Models;

namespace SchoolMSMVC.Controllers
{
    [Authorize(Roles = "Teacher,Supervisor")]
    public class CourseController : Controller   
    {
        // GET: Course
        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<CourseModal> courseList;
            HttpResponseMessage response = GlobalApiConnection.WebApitClient.GetAsync("CoursesApi").Result;
            courseList = response.Content.ReadAsAsync<IEnumerable<CourseModal>>().Result;
            return View(courseList);
        }

        public ActionResult AddorEditCourse(int id = 0)
        {
            if (id == 0)
            {
                return View(new CourseModal());
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.GetAsync("CoursesApi/" + id.ToString()).Result;
                return View(responseMessage.Content.ReadAsAsync<CourseModal>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEditCourse(CourseModal course)
        {
            if (course.CourseID == 0)
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.PostAsJsonAsync("CoursesApi", course).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.PutAsJsonAsync("CoursesApi/" + course.CourseID, course).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if(id == 0)
            {
                return View(new CourseModal());
            }
            else
            {
                HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.GetAsync("CoursesApi/" + id.ToString()).Result;
                return View(responseMessage.Content.ReadAsAsync<CourseModal>().Result);
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.DeleteAsync("CoursesApi/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}