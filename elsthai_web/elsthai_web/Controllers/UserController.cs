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
    public class UserController : Controller
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "57tEJm3ff5GhEcRxjJaoWTgGPjWiI25DK49WsIqA",
            BasePath = "https://kcs-database.firebaseio.com/"
        };
        // IFirebaseClient client;
        public IActionResult Index()
        {
           /* IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Users/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body.ToString());
            var list = new List<User>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<User>(((JProperty)item).Value.ToString()));
            }*/
            
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            IFirebaseClient client = new FirebaseClient(config);
            var data = user;
            PushResponse response = client.Push("Users/", user);
            data.user_id = response.Result.name;
            SetResponse setResponse = client.Set("Users/" + data.user_id, data);


            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult Edit(string email, string name, string phone, string pass)
        {
            User data = new User();
            data.email = email;
            data.name = name;
            data.phone = phone;
            data.password_user = pass;
            
            ViewData["data"] = data;
            return View();
        }
        /*[HttpPost]
        public ActionResult Edit(User user)
        {
            IFirebaseClient client = new FirebaseClient(config);
            SetResponse response = client.Set("Users/" + user.user_id,user);
            
            return RedirectToAction("Index");
        }*/
        [HttpGet]
        public ActionResult Details(string user_id, string password_user, string name, string phone, string email)
        {

            User data = new User();
            data.user_id = user_id;
            data.password_user = password_user;
            data.name = name;
            data.phone = phone;
            data.email = email;
            data.isdelete = "0";
            ViewData["data"] = data;
            return View();
        }
        [HttpGet]
        public ActionResult Delete(string email, string name, string phone, string pass)
        {
            User data = new User();
            data.email = email;
            data.name = name;
            data.phone = phone;
            data.password_user = pass;

            ViewData["data"] = data;
            return View();
        }

    }
}
