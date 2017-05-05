using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp_Speedforce.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
    }

    public class AthleteViewModel
    {
        [Display(Name = "Username")]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Display(Name = "Name")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Display(Name = "LastName")]
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [Display(Name = "BikerType")]
        [JsonProperty("BikerType")]
        public string BikerType { get; set; }

        [Display(Name = "CityName")]
        [JsonProperty("CityName")]
        public string CityName { get; set; }

        [Display(Name = "CountryName")]
        [JsonProperty("CountryName")]
        public string CountryName { get; set; }
    }

    public class AthleteListViewModel
    {
        public AthleteListViewModel(string trainer, List<AthleteViewModel> list)
        {
            Trainer = trainer;
            AthleteList = list;
        }

        public string Trainer { get; set; }
        public List<AthleteViewModel> AthleteList { get; set; }
    }
}