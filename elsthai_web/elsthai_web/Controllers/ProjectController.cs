using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using elsthai_web.Models;
using Firebase.Storage;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace elsthai_web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public ProjectController(IWebHostEnvironment env)
        {
            _environment = env;
        }
        private static string Bucket = "kcs-database.appspot.com";
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "57tEJm3ff5GhEcRxjJaoWTgGPjWiI25DK49WsIqA",
            BasePath = "https://kcs-database.firebaseio.com/"
        };
        // IFirebaseClient client;
        public IActionResult Index()
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Projects/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body.ToString());
            var list = new List<Project>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<Project>(((JProperty)item).Value.ToString()));
            }
            
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(Project project, IFormFile file, IFormFile file2, IFormFile file3)
        {
            FileStream fs = null;
            FileStream fs2 = null;
            FileStream fs3 = null;
            var fileupload = file;
            var fileupload2 = file2;
            var fileupload3 = file3;
            if (fileupload == null)
            {
                IFirebaseClient client = new FirebaseClient(config);
                var data = project;

                PushResponse response = client.Push("Projects/", project);
                data.project_id = response.Result.name;
                SetResponse setResponse = client.Set("Projects/" + data.project_id, data);
            }
            else
            {


                if (fileupload.Length > 0)
                {
                    if (fileupload2 == null && fileupload3 == null)
                    {
                        try
                        {
                            if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                            {
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                            }
                            //ReName Image
                            Guid guid = Guid.NewGuid();

                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = guid + extension;


                            string img = "/imageproject/" + fileName;
                            //
                            string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                            if (Directory.Exists(path2))
                            {
                                using (fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Create))
                                {
                                    await fileupload.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Open);
                            }
                            else
                            {

                            }
                            //
                            //  var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                            //  var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                            //
                            var cancellation = new CancellationTokenSource();

                            var upload = new FirebaseStorage(
                                Bucket,
                                new FirebaseStorageOptions
                                {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                                })
                                .Child("imagesproject")
                                .Child(fileName)
                                .PutAsync(fs, cancellation.Token);
                            try
                            {
                                string link = await upload;
                                project.image = link;
                                IFirebaseClient client = new FirebaseClient(config);
                                var data = project;

                                PushResponse response = client.Push("Projects/", project);
                                data.project_id = response.Result.name;
                                SetResponse setResponse = client.Set("Projects/" + data.project_id, data);


                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"*******************{ex}************************");
                                throw;
                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    else if (fileupload2.Length > 0 && fileupload3 == null)
                    {
                        try
                        {
                            if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\") && !Directory.Exists(_environment.WebRootPath + "\\imageproject2\\"))
                            {
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject2\\");
                            }
                            //ReName Image
                            Guid guid = Guid.NewGuid();
                            Guid guid2 = Guid.NewGuid();
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = guid + extension;

                            string fileName2 = Path.GetFileNameWithoutExtension(file2.FileName);
                            string extension2 = Path.GetExtension(file2.FileName);

                            fileName2 = "image2" + extension2;

                            //
                            string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                            string path3 = Path.Combine(_environment.WebRootPath, $"imageproject2");
                            if (Directory.Exists(path2) && Directory.Exists(path3))
                            {
                                using (fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Create))
                                {
                                    await fileupload.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Open);

                                using (fs2 = new FileStream(Path.Combine(path3, fileupload2.FileName), FileMode.Create))
                                {
                                    await fileupload2.CopyToAsync(fs2);
                                }
                                fs2 = new FileStream(Path.Combine(path3, fileupload2.FileName), FileMode.Open);




                            }

                            //
                            //  var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                            //  var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                            //
                            var cancellation = new CancellationTokenSource();
                            var cancellation2 = new CancellationTokenSource();

                            var upload = new FirebaseStorage(
                                Bucket,
                                new FirebaseStorageOptions
                                {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                                })
                                .Child("imagesproject")
                                .Child(fileName)
                                .PutAsync(fs, cancellation.Token);

                            var upload2 = new FirebaseStorage(
                               Bucket,
                               new FirebaseStorageOptions
                               {
                                   //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                   ThrowOnCancel = true
                               })
                               .Child("imagesproject")
                               .Child(fileName2)
                               .PutAsync(fs2, cancellation2.Token);
                            try
                            {
                                string link = await upload;
                                string link2 = await upload2;
                                project.image = link;
                                project.image2 = link2;
                                IFirebaseClient client = new FirebaseClient(config);
                                var data = project;

                                PushResponse response = client.Push("Projects/", project);
                                data.project_id = response.Result.name;
                                SetResponse setResponse = client.Set("Projects/" + data.project_id, data);


                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"*******************{ex}************************");
                                throw;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    else if (fileupload.Length > 0 && fileupload2.Length > 0 && fileupload3.Length > 0)
                    {
                        try
                        {
                            if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                            {
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                            }
                            //ReName Image
                            Guid guid = Guid.NewGuid();
                            Guid guid2 = Guid.NewGuid();
                            Guid guid3 = Guid.NewGuid();

                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = guid + extension;

                            string fileName2 = Path.GetFileNameWithoutExtension(file2.FileName);
                            string extension2 = Path.GetExtension(file2.FileName);
                            fileName2 = guid2 + extension2;

                            string fileName3 = Path.GetFileNameWithoutExtension(file3.FileName);
                            string extension3 = Path.GetExtension(file3.FileName);
                            fileName3 = guid3 + extension3;


                            //
                            string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                            if (Directory.Exists(path2))
                            {
                                using (fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Create))
                                {
                                    await fileupload.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Open);

                                using (fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Create))
                                {
                                    await fileupload3.CopyToAsync(fs2);
                                }
                                fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Open);

                                using (fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Create))
                                {
                                    await fileupload3.CopyToAsync(fs3);
                                }
                                fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Open);


                            }
                            else
                            {

                            }
                            //
                            //  var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                            //  var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                            //
                            var cancellation = new CancellationTokenSource();
                            var cancellation2 = new CancellationTokenSource();
                            var cancellation3 = new CancellationTokenSource();

                            var upload = new FirebaseStorage(
                                Bucket,
                                new FirebaseStorageOptions
                                {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                                })
                                .Child("imagesproject")
                                .Child(fileName)
                                .PutAsync(fs, cancellation.Token);

                            var upload2 = new FirebaseStorage(
                               Bucket,
                               new FirebaseStorageOptions
                               {
                                   //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                   ThrowOnCancel = true
                               })
                               .Child("imagesproject")
                               .Child(fileName2)
                               .PutAsync(fs2, cancellation2.Token);

                            var upload3 = new FirebaseStorage(
                              Bucket,
                              new FirebaseStorageOptions
                              {
                                  //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                  ThrowOnCancel = true
                              })
                              .Child("imagesproject")
                              .Child(fileName3)
                              .PutAsync(fs3, cancellation3.Token);
                            try
                            {
                                string link = await upload;
                                string link2 = await upload2;
                                string link3 = await upload3;
                                project.image = link;
                                project.image2 = link2;
                                project.image3 = link3;
                                IFirebaseClient client = new FirebaseClient(config);
                                var data = project;

                                PushResponse response = client.Push("Projects/", project);
                                data.project_id = response.Result.name;
                                SetResponse setResponse = client.Set("Projects/" + data.project_id, data);


                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"*******************{ex}************************");
                                throw;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }
            

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string project_id, string nameproject, string type, string goal, string detail, string image, string image2, string image3)
        {
            IFirebaseClient client = new FirebaseClient(config);
            FirebaseResponse response = client.Get("Projects/" + project_id);
            Project data = JsonConvert.DeserializeObject<Project>(response.Body.ToString());
            

            ViewData["data"] = data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project project, IFormFile file, IFormFile file2, IFormFile file3)
        {
            FileStream fs = null;
            FileStream fs2 = null;
            FileStream fs3 = null;
            var fileupload = file;
            var fileupload2 = file2;
            var fileupload3 = file3;

            if (fileupload == null)
            {
                IFirebaseClient client = new FirebaseClient(config);
                SetResponse response = client.Set("Projects/" + project.project_id, project);
            }else if (fileupload == null && fileupload2.Length>0 && fileupload3 == null)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                    }
                    //ReName Image

                    Guid guid2 = Guid.NewGuid();
                    string fileName2 = Path.GetFileNameWithoutExtension(file2.FileName);
                    string extension2 = Path.GetExtension(file2.FileName);
                    fileName2 = guid2 + extension2;

                    string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                    if (Directory.Exists(path2))
                    {
                        using (fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Create))
                        {
                            await fileupload2.CopyToAsync(fs2);
                        }
                        fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Open);
                    }

                    var cancellation2 = new CancellationTokenSource();

                    var upload2 = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                        })
                        .Child("imagesproject")
                        .Child(fileName2)
                        .PutAsync(fs2, cancellation2.Token);
                    try
                    {
                        string link2 = await upload2;
                        project.image2 = link2;

                        IFirebaseClient client = new FirebaseClient(config);
                        SetResponse response = client.Set("Projects/" + project.project_id, project);

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"*******************{ex}************************");
                        throw;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (fileupload == null && fileupload3.Length > 0 && fileupload2 == null)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                    }
                    //ReName Image

                    Guid guid3 = Guid.NewGuid();
                    string fileName3 = Path.GetFileNameWithoutExtension(file3.FileName);
                    string extension3 = Path.GetExtension(file3.FileName);
                    fileName3 = guid3 + extension3;

                    string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                    if (Directory.Exists(path2))
                    {
                        using (fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Create))
                        {
                            await fileupload3.CopyToAsync(fs3);
                        }
                        fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Open);
                    }

                    var cancellation3 = new CancellationTokenSource();

                    var upload3 = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                        })
                        .Child("imagesproject")
                        .Child(fileName3)
                        .PutAsync(fs3, cancellation3.Token);
                    try
                    {
                        string link3 = await upload3;
                        project.image3 = link3;

                        IFirebaseClient client = new FirebaseClient(config);
                        SetResponse response = client.Set("Projects/" + project.project_id, project);

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"*******************{ex}************************");
                        throw;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (fileupload == null && fileupload3.Length > 0 && fileupload2.Length>0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                    }
                    //ReName Image

                    Guid guid2 = Guid.NewGuid();
                    string fileName2 = Path.GetFileNameWithoutExtension(file2.FileName);
                    string extension2 = Path.GetExtension(file2.FileName);
                    fileName2 = guid2 + extension2;
                    //
                    Guid guid3 = Guid.NewGuid();
                    string fileName3 = Path.GetFileNameWithoutExtension(file3.FileName);
                    string extension3 = Path.GetExtension(file3.FileName);
                    fileName3 = guid3 + extension3;

                    string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                    if (Directory.Exists(path2))
                    {
                        using (fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Create))
                        {
                            await fileupload2.CopyToAsync(fs2);
                        }
                        fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Open);

                        using(fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Create))
                        {
                            await fileupload3.CopyToAsync(fs3);
                        }
                        fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Open);
                    }

                    var cancellation2 = new CancellationTokenSource();
                    var cancellation3 = new CancellationTokenSource();
                    
                    var upload2 = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                        })
                        .Child("imagesproject")
                        .Child(fileName2)
                        .PutAsync(fs2, cancellation2.Token);

                    var upload3 = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                            //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true
                        })
                        .Child("imagesproject")
                        .Child(fileName3)
                        .PutAsync(fs3,cancellation3.Token);

                    try
                    {
                        string link2 = await upload2;
                        project.image2 = link2;
                        string link3 = await upload3;
                        project.image3 = link3;

                        IFirebaseClient client = new FirebaseClient(config);
                        SetResponse response = client.Set("Projects/" + project.project_id, project);

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"*******************{ex}************************");
                        throw;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else 
            {


                if (fileupload.Length > 0)
                {
                    if (fileupload2 == null && fileupload3 == null)
                    {
                        try
                        {
                            if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                            {
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                            }
                            //ReName Image

                            Guid guid = Guid.NewGuid();
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = guid + extension;

                            string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                            if (Directory.Exists(path2))
                            {
                                using (fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Create))
                                {
                                    await fileupload.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Open);
                            }

                            var cancellation = new CancellationTokenSource();

                            var upload = new FirebaseStorage(
                                Bucket,
                                new FirebaseStorageOptions
                                {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                                })
                                .Child("imagesproject")
                                .Child(fileName)
                                .PutAsync(fs, cancellation.Token);
                            try
                            {
                                string link = await upload;
                                project.image = link;

                                IFirebaseClient client = new FirebaseClient(config);
                                SetResponse response = client.Set("Projects/" + project.project_id, project);

                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"*******************{ex}************************");
                                throw;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    else if (fileupload2.Length > 0 && fileupload3 == null)
                    {
                        try
                        {
                            if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                            {
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                            }
                            //ReName Image
                            Guid guid = Guid.NewGuid();
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = guid + extension;

                            Guid guid2 = Guid.NewGuid();
                            string fileName2 = Path.GetFileNameWithoutExtension(file2.FileName);
                            string extension2 = Path.GetExtension(file2.FileName);
                            fileName2 = guid2 + extension2;



                            string img = "/imageproject/" + fileName;
                            //
                            string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                            if (Directory.Exists(path2))
                            {
                                using (fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Create))
                                {
                                    await fileupload.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Open);


                                using (fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Create))
                                {
                                    await fileupload2.CopyToAsync(fs2);
                                }
                                fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Open);


                            }
                            else
                            {

                            }
                            //
                            //  var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                            //  var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                            //
                            var cancellation = new CancellationTokenSource();
                            var cancellation2 = new CancellationTokenSource();

                            var upload = new FirebaseStorage(
                                Bucket,
                                new FirebaseStorageOptions
                                {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                                })
                                .Child("imagesproject")
                                .Child(fileName)
                                .PutAsync(fs, cancellation.Token);

                            var upload2 = new FirebaseStorage(
                               Bucket,
                               new FirebaseStorageOptions
                               {
                                   //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                   ThrowOnCancel = true
                               })
                               .Child("imagesproject")
                               .Child(fileName2)
                               .PutAsync(fs2, cancellation2.Token);
                            try
                            {
                                string link = await upload;
                                string link2 = await upload2;
                                project.image = link;
                                project.image2 = link2;

                                IFirebaseClient client = new FirebaseClient(config);
                                SetResponse response = client.Set("Projects/" + project.project_id, project);


                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"*******************{ex}************************");
                                throw;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    else if (fileupload.Length > 0 && fileupload2.Length > 0 && fileupload3.Length > 0)
                    {
                        try
                        {
                            if (!Directory.Exists(_environment.WebRootPath + "\\imageproject\\"))
                            {
                                Directory.CreateDirectory(_environment.WebRootPath + "\\imageproject\\");
                            }
                            //ReName Image
                            Guid guid = Guid.NewGuid();
                            Guid guid2 = Guid.NewGuid();
                            Guid guid3 = Guid.NewGuid();

                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = guid + extension;

                            string fileName2 = Path.GetFileNameWithoutExtension(file2.FileName);
                            string extension2 = Path.GetExtension(file2.FileName);
                            fileName2 = guid2 + extension2;

                            string fileName3 = Path.GetFileNameWithoutExtension(file3.FileName);
                            string extension3 = Path.GetExtension(file3.FileName);
                            fileName3 = guid3 + extension3;



                            string img = "/imageproject/" + fileName;
                            //
                            string path2 = Path.Combine(_environment.WebRootPath, $"imageproject");
                            if (Directory.Exists(path2))
                            {
                                using (fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Create))
                                {
                                    await fileupload.CopyToAsync(fs);
                                }
                                fs = new FileStream(Path.Combine(path2, fileupload.FileName), FileMode.Open);

                                using (fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Create))
                                {
                                    await fileupload2.CopyToAsync(fs2);
                                }
                                fs2 = new FileStream(Path.Combine(path2, fileupload2.FileName), FileMode.Open);

                                using (fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Create))
                                {
                                    await fileupload3.CopyToAsync(fs3);
                                }
                                fs3 = new FileStream(Path.Combine(path2, fileupload3.FileName), FileMode.Open);


                            }
                            else
                            {

                            }
                            //
                            //  var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                            //  var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
                            //
                            var cancellation = new CancellationTokenSource();
                            var cancellation2 = new CancellationTokenSource();
                            var cancellation3 = new CancellationTokenSource();

                            var upload = new FirebaseStorage(
                                Bucket,
                                new FirebaseStorageOptions
                                {
                                    //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                    ThrowOnCancel = true
                                })
                                .Child("imagesproject")
                                .Child(fileName)
                                .PutAsync(fs, cancellation.Token);

                            var upload2 = new FirebaseStorage(
                               Bucket,
                               new FirebaseStorageOptions
                               {
                                   //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                   ThrowOnCancel = true
                               })
                               .Child("imagesproject")
                               .Child(fileName2)
                               .PutAsync(fs2, cancellation2.Token);

                            var upload3 = new FirebaseStorage(
                              Bucket,
                              new FirebaseStorageOptions
                              {
                                  //  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                  ThrowOnCancel = true
                              })
                              .Child("imagesproject")
                              .Child(fileName3)
                              .PutAsync(fs3, cancellation3.Token);
                            try
                            {
                                string link = await upload;
                                string link2 = await upload2;
                                string link3 = await upload3;
                                project.image = link;
                                project.image2 = link2;
                                project.image3 = link3;

                                IFirebaseClient client = new FirebaseClient(config);
                                SetResponse response = client.Set("Projects/" + project.project_id, project);


                                return RedirectToAction("Index");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"*******************{ex}************************");
                                throw;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                else//ifใหญ่
                {
                    IFirebaseClient client = new FirebaseClient(config);
                    SetResponse response = client.Set("Projects/" + project.project_id, project);
                }
                /* IFirebaseClient client = new FirebaseClient(config);
                 SetResponse response = client.Set("Projects/"+ project.project_id,project);*/
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(/*string project_id, string nameproject, string type, string goal, string detail*/)
        {

           /* Project data = new Project();
            data.project_id = project_id;
            data.nameproject = nameproject;
            data.type = type;
            data.goal = goal;
            data.detail = detail;
            data.isdelete = "0";
            ViewData["data"] = data;*/
            return View();
        }
        [HttpGet]
        public ActionResult Delete(string project_id, string nameproject, string type, string goal, string detail)
        {
            IFirebaseClient client = new FirebaseClient(config);
            Project data = new Project();
            data.project_id = project_id;
            data.nameproject = nameproject;
            data.type = type;
            data.goal = goal;
            data.detail = detail;
            data.isdelete = "1";           
            SetResponse response = client.Set("Projects/" + data.project_id, data);
            return RedirectToAction("Index"); 
        }

    }
}
