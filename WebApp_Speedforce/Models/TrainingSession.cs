using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace WebApp_Speedforce.Models
{
    public class TrainingSession
    {
        public String SessionID { get; set; }
        public String UserID { get; set; }
        public Double AverageBPM { get; set; }
        public Double BurntCalories { get; set; }
        public String RouteID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Double Distance { get; set; }
        public Double RelativeHumidity { get; set; }
        public Double Temperature { get; set; }
        public String TrainingTypeID { get; set; }
        public String SessionStatusID { get; set; }
        public String ClimateConditionID { get; set; }

        public TrainingSession() { }

        public async void GetTrainingSession(string id)
        {
            HttpClient client = new HttpClient();
            TrainingSession ts = new TrainingSession();
            HttpResponseMessage response = await client.GetAsync("http://speedforceservice.azurewebsites.net/api/training/challenge/"+id);
            if( response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                
            }

        }
    }
}