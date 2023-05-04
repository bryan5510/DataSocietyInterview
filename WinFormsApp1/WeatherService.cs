using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class WeatherService
{
    private static readonly HttpClient httpClient = new HttpClient();
    private const string BaseUrl = "https://api.weather.gov";

    public async Task<double> GetTemperatureAsync(double latitude, double longitude)
    {
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "myweatherapp.com (contact@myweatherapp.com)");
        httpClient.DefaultRequestHeaders.Add("Accept", "application/geo+json");

        //var requestUrl = new Uri($"{BaseUrl}/points/{latitude.ToString("G", CultureInfo.InvariantCulture)},{longitude.ToString("G", CultureInfo.InvariantCulture)}");
        var requestUrl = new Uri($"{BaseUrl}/points/{latitude.ToString()},{longitude.ToString()}");
        HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(content);

            // Retrieve the forecast URL
            string forecastUrl = jsonResponse["properties"]["forecast"].ToString();

            // Get the forecast data
            HttpResponseMessage forecastResponse = await httpClient.GetAsync(forecastUrl);
            if (forecastResponse.IsSuccessStatusCode)
            {
                string forecastContent = await forecastResponse.Content.ReadAsStringAsync();
                JObject forecastJsonResponse = JObject.Parse(forecastContent);
                JArray periods = (JArray)forecastJsonResponse["properties"]["periods"];
                JObject wednesdayPeriod = null;

                //if today is wednesday, dont loop looking for it
                if (DateTime.Now.DayOfWeek.ToString() == "Wednesday") {
                    wednesdayPeriod = (periods[0]["name"].ToString() == "Tonight") ? (JObject)periods[0] : (JObject)periods[1];
                } else {
                    for (int i = 0; i < periods.Count; i++)
                    {
                        if (periods[i]["name"].ToString() == "Wednesday Night")
                        {
                            wednesdayPeriod = (JObject)periods[i];
                            break;
                        }
                    }
                }

                double temperature = wednesdayPeriod["temperature"].Value<double>();
                return temperature;
            }
            else
            {
                throw new Exception($"Unable to retrieve forecast data: API response: {forecastResponse.StatusCode} - {forecastResponse.ReasonPhrase}");
            }
        }
        else
        {
            throw new Exception($"Unable to retrieve temperature data, latitude and longitude were likely invalid. API response: {response.StatusCode} - {response.ReasonPhrase}");
        }

        throw new Exception("Unable to retrieve temperature data.");
    }

}
