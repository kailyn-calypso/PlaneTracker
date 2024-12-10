using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
//\/https://fr24api.flightradar24.com/
////https://aviationstack.com/documentation
namespace PlaneTracker
{
    [Serializable]
    public class PlaneLocation
    {
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string airline_icao_code { get; set; }
        public int airline_iata_code { get; set; }
        public string plane_status { get; set; }
        public string registration_number { get; set; }
        public string production_line { get; set; }

        public PLaneTracker  :this(0, 0, string.Empty, 0, string.Empty, string .Empty, string.Empty)
            { 
            } // end constructor 

    }

    public class LocationAPI
    {
        private const string URL = "https://api.aviationstack.com/v1/flights";
        private string urlParameters = "?api_key=3fd198d3e525ba3f0490e5494b620ed2";

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete.
            // This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically
            // when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}