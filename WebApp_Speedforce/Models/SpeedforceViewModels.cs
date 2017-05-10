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

    public class TrainerRegisterViewModel
    {
        public TrainerRegisterViewModel(List<string> list)
        {
            Countries = list;
        }

        public TrainerRegisterViewModel() { }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Display(Name = "BirthDate")]
        public string BirthDate { get; set; }

        [Display(Name = "CityName")]
        public string CityName { get; set; }

        [Display(Name = "CountryName")]
        public string CountryName { get; set; }

        [Display(Name = "TelephoneNumber")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Certified")]
        public bool Certified { get; set; }

        public List<string> Countries { get; set; }
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

        public AthleteListViewModel() { }

        [Display(Name = "Trainer")]
        public string Trainer { get; set; }

        [Display(Name = "Athlete")]
        public string Athlete { get; set; }

        public List<AthleteViewModel> AthleteList { get; set; }
    }
}