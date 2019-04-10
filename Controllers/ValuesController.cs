using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_API_101.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace test101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<Login> logins = new List<Login>();

        private readonly IHostingEnvironment _hostingEnvironment;
        public ValuesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Login>> Get()
        {
            string path= ($"{_hostingEnvironment.WebRootPath}/data.json");
        
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                logins = JsonConvert.DeserializeObject<List<Login>>(json);
                return logins;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Login> Get(int id)
        {
            string path= ($"{_hostingEnvironment.WebRootPath}/data.json");
        
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                logins = JsonConvert.DeserializeObject<List<Login>>(json);
                return logins[id];
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Login login)
        {
            string path= ($"{_hostingEnvironment.WebRootPath}/data.json");
    
            logins.Add(login);
            
            string stringify = JsonConvert.SerializeObject(logins, Formatting.Indented);
            
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(stringify);
            }

            return Content("Content Added Successfully");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Login login)
        {
            string path= ($"{_hostingEnvironment.WebRootPath}/data.json");
    
            logins[id] = login;
            
            string stringify = JsonConvert.SerializeObject(logins, Formatting.Indented);
            
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(stringify);
            }

            return Content("Content Updated Successfully");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string path= ($"{_hostingEnvironment.WebRootPath}/data.json");

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Login> items = JsonConvert.DeserializeObject<List<Login>>(json);
                items.RemoveAt(id);

                string stringify = JsonConvert.SerializeObject(items, Formatting.Indented);
                
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(stringify);
                }
            }
            
            return Content("Content Removed Successfully");
        }
    }
}
