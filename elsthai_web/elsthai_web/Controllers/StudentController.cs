using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elsthai_web.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace elsthai_web.Controllers
{
    public class StudentController : Controller
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "57tEJm3ff5GhEcRxjJaoWTgGPjWiI25DK49WsIqA",
            BasePath = "https://kcs-database.firebaseio.com/"
        };
        // IFirebaseClient client;
        public IActionResult Index()
        {
            
                      
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            IFirebaseClient client = new FirebaseClient(config);
            PushResponse response = client.Push("Students/", student);
            return View();
            /*   
               try
               {
                   AddStudentToFirebase(student);
                   ModelState.AddModelError(string.Empty, "Add Successfully");
               }
               catch(Exception ex)
               {
                   ModelState.AddModelError(string.Empty, "Not Successfully"+ex.Message);
               }
               AddStudentToFirebase(student);
               return View();
           }

           private void AddStudentToFirebase(Student student)
           {


               client = new FireSharp.FirebaseClient(config);
               var data = student;
               PushResponse response = client.Push("Students/", data);

               data.student_id = response.Result.name;
               SetResponse setResponse = client.Set("Students/" + data.student_id, data);
           }*/
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Students/" + id);
            Student data = JsonConvert.DeserializeObject<Student>(response.Body.ToString());
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            IFirebaseClient client = new FirebaseClient(config);
            SetResponse response = client.Set("Students/"+student.student_id,student);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(string id)
        {


            IFirebaseClient client = new FirebaseClient(config);
          
            FirebaseResponse response = client.Get("Students/"+id);
            string data = JsonConvert.DeserializeObject<string>(response.Body.ToString());
           
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Delete("Students/" +id);

            return RedirectToAction("Index");
        }

    }
}
