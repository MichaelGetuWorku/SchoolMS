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
    public class StudentController : Controller
    {
        // GET: Student
        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<StudentModel> studentList;
            HttpResponseMessage response = GlobalApiConnection.WebApitClient.GetAsync("StudentsApi").Result;
            studentList = response.Content.ReadAsAsync<IEnumerable<StudentModel>>().Result;

            Console.WriteLine("--------------------------------");
            Console.WriteLine(studentList);
            return View(studentList);
        }

        //get the form with the modal
        public ActionResult AddOrEditStudent(int id = 0)
        {
            // if id is === 0 new srudent will be create using the form from the modal
            if (id == 0)
                return View(new StudentModel());
            else
            {
                // it id is === to some id we will edit the student record and post it
                HttpResponseMessage response = GlobalApiConnection.WebApitClient.GetAsync("StudentsApi/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<StudentModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditStudent(StudentModel student)
        {
            if (student.StudentID == 0)
            {
                HttpResponseMessage response = GlobalApiConnection.WebApitClient.PostAsJsonAsync("StudentsApi", student).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalApiConnection.WebApitClient.PutAsJsonAsync("StudentsApi/" + student.StudentID, student).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }


            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return View(new StudentModel());
            }
            else
            {
                HttpResponseMessage response = GlobalApiConnection.WebApitClient.GetAsync("StudentsApi/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<StudentModel>().Result);
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage responseMessage = GlobalApiConnection.WebApitClient.DeleteAsync("StudentsApi/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}