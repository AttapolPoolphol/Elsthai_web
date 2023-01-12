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

using static elsthai_web.Controllers.ReportdonetController;

namespace elsthai_web.Controllers
{
    public class ReportdonetController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "57tEJm3ff5GhEcRxjJaoWTgGPjWiI25DK49WsIqA",
            BasePath = "https://kcs-database.firebaseio.com/"
        };
        public IActionResult Index()
        {
          /*  IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Users/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body.ToString());
            var list = new List<User>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<User>(((JProperty)item).Value.ToString()));
            }
*/
            return View();
           
        }
        [HttpGet]
        public IActionResult Show()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Projects/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body.ToString());
            var list = new List<Project>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Project>(((JProperty)item).Value.ToString()));
            }
            ViewData["data"] = data;
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Reportdonet reportdonet)
        {
            Reportdonet r = reportdonet;
            DateTime aDate = DateTime.Now;
            string day = aDate.ToString("dd");
            string month = aDate.ToString("MM");
            string year = aDate.ToString("yyyy");
            r.date = day + " " + month + " " + year;
            Random rnd = new Random();
            int no = rnd.Next(1000,10000);
            r.no = no.ToString();
            IFirebaseClient client = new FirebaseClient(config);
            var data = r;

            PushResponse response = client.Push("Reportdonets/", r);
            data.reportdonet_id = response.Result.name;
            SetResponse setResponse = client.Set("Reportdonets/" + data.reportdonet_id, data);

            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public IActionResult Receipt(string name,string AccountNumber,string project,string Volume,string bank)
        {
            /* IFirebaseClient client = new FirebaseClient(config);
             FirebaseResponse response = client.Get("Reportdonets/" + reportdonet_id);
             Reportdonet data = JsonConvert.DeserializeObject<Reportdonet>(response.Body.ToString());*/
            
            Reportdonet r = new Reportdonet();
            DateTime aDate = DateTime.Now;
            string day = aDate.ToString("dd");
            string month = aDate.ToString("MM");
            string year = aDate.ToString("yyyy");
            r.date = day + " " + month + " " + year;
            r.name_user = name;
            r.no = AccountNumber;
            r.donateproject = project;
            r.price = Volume;
            r.money = "เงินโอน ธนาคาร" +bank;
               ViewData["data"] = r;

            return View();
        }
        [HttpGet]
        public IActionResult CloudFS()
        {
            

            return View();
        }
        [HttpGet]
        public IActionResult History(string email)
        {
            User data = new User();
            data.email = email;
            ViewData["data"] = data;

            return View();
        }


    }
    
}
