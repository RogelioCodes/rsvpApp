using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//references: https://openweathermap.org/current and https://www.youtube.com/watch?v=j5YawkCPcx8
namespace FinalProject.Helper
{
    class WeatherApiCaller
    {   
        //authid is used to send auth id to api so we can use the api
        public static async Task<ApiResponse> Get(string url, string authId = null) //authId is set to null to make it optional
        {
            var client = new HttpClient();
            using (client)
            {
                if (!string.IsNullOrWhiteSpace(authId))//checking that authId exists, is not null or whitespace
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", authId);

                var request = await client.GetAsync(url); //getting response code 
                if (request.IsSuccessStatusCode)
                {
                    return new ApiResponse { Response = await request.Content.ReadAsStringAsync() };
                }
                else //if response code is not successful then return error message
                    return new ApiResponse { ErrorMessage = request.ReasonPhrase };
            }
        }
    }
    public class ApiResponse
    {
        public bool Successful => ErrorMessage == null; //if error message is null then api is not successful
        public string ErrorMessage { get; set; }
        public string Response { get; set; }
    }
}
