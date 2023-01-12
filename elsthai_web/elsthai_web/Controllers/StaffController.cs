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
    public class StaffController : Controller
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "57tEJm3ff5GhEcRxjJaoWTgGPjWiI25DK49WsIqA",
            BasePath = "https://kcs-database.firebaseio.com/"
        };
        // IFirebaseClient client;
        public IActionResult Index()
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Staffs/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body.ToString());
            var list = new List<Staff>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Staff>(((JProperty)item).Value.ToString()));
            }
            
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            IFirebaseClient client = new FirebaseClient(config);
            var data = staff;
            
            PushResponse response = client.Push("Staffs/", data);
            data.staff_id = response.Result.name;
            SetResponse setResponse = client.Set("Staffs/" + data.staff_id, data);
           
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Edit(string staff_id, string password_staff, string name, string phone, string email)
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Staffs/" + staff_id);
            Staff data = JsonConvert.DeserializeObject<Staff>(response.Body.ToString());
            
           
            ViewData["data"] = data;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            IFirebaseClient client = new FirebaseClient(config);
            SetResponse response = client.Set("Staffs/" +staff.staff_id,staff);            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(string staff_id, string password_staff, string name, string phone, string email)
        {

            Staff data = new Staff();
            data.staff_id = staff_id;
            data.password_staff = password_staff;
            data.name = name;
            data.phone = phone;
            data.email = email;
            data.isdelete = "0";
            ViewData["data"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult Delete(string staff_id, string password_staff, string name, string phone, string email)
        {
            IFirebaseClient client = new FirebaseClient(config);
            Staff data = new Staff();
            data.staff_id = staff_id;
            data.password_staff = password_staff;
            data.name = name;
            data.phone = phone;
            data.email = email;
            data.isdelete = "1";
            ViewData["data"] = data;
            SetResponse response = client.Set("Staffs/" + data.staff_id, data);
            return RedirectToAction("Index"); 
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Staff staff)
        {
            
            
            if (staff.email =="waranyajibi@gmail.com" && staff.password_staff =="123456")
            {
                return RedirectToAction("Index");
            }
            else
            {
                string staff_id = "-" + staff.staff_id;
                IFirebaseClient client = new FirebaseClient(config);
                FirebaseResponse response = client.Get("Staffs/" + staff_id);
                Staff data = JsonConvert.DeserializeObject<Staff>(response.Body.ToString());

                if(data != null)
                {
                    if (data.password_staff == staff.password_staff)
                    {
                        return View("/user/index");
                    }
                        
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            } 
                
                
                
            
            
        }
    }
}
