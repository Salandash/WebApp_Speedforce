using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
        public async Task<ActionResult> LoginPost(Models.UserLoginViewModel model)
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
            model.Role = "Atleta";

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

            // If transaction is successful
            return Content(responseJson, "application/json");
        }
    }
}