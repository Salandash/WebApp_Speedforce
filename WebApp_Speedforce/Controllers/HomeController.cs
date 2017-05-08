using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_Speedforce.Models;

namespace WebApp_Speedforce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login to your Speedforce account.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginPost(UserLoginViewModel model)
        {
            // URL to Speedforce API
            string url = "http://speedforceservice.azurewebsites.net/api/users/loginA";

            // JSON Response to Display
            string responseJson = "N/A";

            // JSON Object to build
            var json = new JObject();

            // Verifying model
            if (model.Username == null)
                model.Username = "N/A";
            if (model.Password == null)
                model.Password = "N/A";
            model.Role = "Entrenador";
            //model.Role = "Atleta";

            // Building JSON to send
            json["Username"] = model.Username;
            json["Password"] = model.Password;
            json["Role"] = model.Role;

            // HTTP transaction
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage response = await client.PostAsync(url, new StringContent(json.ToString(), Encoding.UTF8, "application/json")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            responseJson = await content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch
            {
                // If transaction fails
                return Content("Problemas conectando con Speedforce API.");
            }

            var user = JObject.Parse(responseJson);

            // If transaction is successful
            // return Content(user["Username"].ToString());

            return RedirectToAction("Athletes", "Home", new { username = user["Username"].ToString() });
        }

        public async Task<ActionResult> Athletes(string username)
        {
            // URL to Speedforce API
            string url = "http://speedforceservice.azurewebsites.net/api/users/athleteList/" + username;

            // Athletes JSON Array from API
            string responseJsonArray = "N/A";

            // HTTP transaction
            try
            {
                using (var client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            responseJsonArray = await content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch
            {
                // If transaction fails
                return Content("Problemas conectando con Speedforce API.");
            }

            // JSON Object to build
            var jsonArray = JArray.Parse(responseJsonArray);
            var list = new List<AthleteViewModel>();

            foreach (var jsonToken in jsonArray)
            {
                list.Add(JsonConvert.DeserializeObject<AthleteViewModel>(jsonToken.ToString()));
            }

            // If transaction is successful
            return View(new AthleteListViewModel(username, list));
        }

        public async Task<ActionResult> UnbindAthlete(string trainer, string athlete)
        {
            // URL to Speedforce API
            string url = "http://speedforceservice.azurewebsites.net/api/users/removeA";

            // Response String
            string responseString = "N/A";

            // JSON Object to build
            var json = new JObject();
            json["trainerid"] = trainer;
            json["athleteid"] = athlete;

            // HTTP transaction
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage response = await client.PostAsync(url, new StringContent(json.ToString(), Encoding.UTF8, "application/json")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            responseString = await content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch
            {
                // If transaction fails
                return Content("Problemas desconectando atleta en Speedforce API.");
            }

            // If transaction is successful
            return RedirectToAction("Athletes", "Home", new { username = trainer });
        }

        [HttpPost]
        public async Task<ActionResult> PairAthlete(AthleteListViewModel model)
        {
            // URL to Speedforce API
            string url = "http://speedforceservice.azurewebsites.net/api/users/trainer/athlete";

            // Response String
            string responseString = "N/A";

            // JSON Object to build
            var json = new JObject();
            json["trainerid"] = model.Trainer;
            json["athleteid"] = model.Athlete;

            // HTTP transaction
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (HttpResponseMessage response = await client.PostAsync(url, new StringContent(json.ToString(), Encoding.UTF8, "application/json")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            responseString = await content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch
            {
                // If transaction fails
                return Content("Problemas vinculando atleta en Speedforce API.");
            }

            // If transaction is successful
            return RedirectToAction("Athletes", "Home", new { username = model.Trainer });
        }
    }
}