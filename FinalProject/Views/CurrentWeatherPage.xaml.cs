using FinalProject.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalProject.Model;
//references: https://openweathermap.org/current and https://www.youtube.com/watch?v=j5YawkCPcx8
namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentWeatherPage : ContentPage
    {
        public CurrentWeatherPage()
        {
            InitializeComponent();
            GetWeatherInfo();
        }

        private string Location = "Coachella";// this is the default value but if the api response is successful then this value is overwritten
        private string Id = "18c1b354485712afd17acb727e4ea5ce";
    private async void GetWeatherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid={Id}&units=imperial"; //replacing location with our location varible
            var result = await WeatherApiCaller.Get(url);
            if(result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response); //getting all weather info
                    descriptionTxt.Text = weatherInfo.weather[0].description.ToUpper();
                    iconImg.Source = $"w{weatherInfo.weather[0].icon}";
                    cityTxt.Text = weatherInfo.name.ToUpper();
                    temperatureTxt.Text = weatherInfo.main.temp.ToString("0");
                    humidityTxt.Text = $"{weatherInfo.main.humidity}%";
                    pressureTxt.Text = $"{weatherInfo.main.pressure} hpa";
                    windTxt.Text = $"{weatherInfo.wind.speed} m/s";
                    cloudinessTxt.Text = $"{weatherInfo.clouds.all}%";
                    
                   var dt = new DateTime(1970, 1, 1).AddSeconds(weatherInfo.dt);//1970/1/1 is passed as an offset then we calculate the time using Addseconds.
                    //weatherInfo.dt comes from the api and represents seconds that have passed
                    dateTxt.Text = dt.ToString("dddd, MMM dd").ToUpper();//converted to proper date format
                    GetForecast();
                }
                catch(Exception e)
                {
                    await DisplayAlert("Weather Info", e.Message, "OK");
                }
            }
            else//display error message
            {
                await DisplayAlert("Weather Info", "No weather information found", "OK");
            }
        }
        private async void GetForecast()
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={Location}&appid={Id}&units=imperial";
            var result = await WeatherApiCaller.Get(url);
            if (result.Successful) //if the api works 
            {
                try
                {
                    var forcastInfo = JsonConvert.DeserializeObject<ForecastInfo>(result.Response);
                    //deserializing the json object ForecastInfo
                    List<List> MyList = new List<List>();
                    //putting information into list
                    foreach (var list in forcastInfo.list)
                    {
                       //weather forecast is returned for every hour 
                        var date = DateTime.Parse(list.dt_txt);

                        if (date > DateTime.Now && date.Hour == 0 && date.Minute == 0 && date.Second == 0)
                            MyList.Add(list);
                    }

                    dayOneTxt.Text = DateTime.Parse(MyList[0].dt_txt).ToString("dddd");
                    dateOneTxt.Text = DateTime.Parse(MyList[0].dt_txt).ToString("dd MMM");
                    iconOneImg.Source = $"w{MyList[0].weather[0].icon}";
                    tempOneTxt.Text = MyList[0].main.temp.ToString("0");

                    dayTwoTxt.Text = DateTime.Parse(MyList[1].dt_txt).ToString("dddd");
                    dateTwoTxt.Text = DateTime.Parse(MyList[1].dt_txt).ToString("dd MMM");
                    iconTwoImg.Source = $"w{MyList[1].weather[0].icon}";
                    tempTwoTxt.Text = MyList[1].main.temp.ToString("0");

                    dayThreeTxt.Text = DateTime.Parse(MyList[2].dt_txt).ToString("dddd");
                    dateThreeTxt.Text = DateTime.Parse(MyList[2].dt_txt).ToString("dd MMM");
                    iconThreeImg.Source = $"w{MyList[2].weather[0].icon}";
                    tempThreeTxt.Text = MyList[2].main.temp.ToString("0");

                    dayFourTxt.Text = DateTime.Parse(MyList[3].dt_txt).ToString("dddd");
                    dateFourTxt.Text = DateTime.Parse(MyList[3].dt_txt).ToString("dd MMM");
                    iconFourImg.Source = $"w{MyList[3].weather[0].icon}";
                    tempFourTxt.Text = MyList[3].main.temp.ToString("0");

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Weather Info", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Weather Info", "No forecast information found", "OK");
            }
        }
    }

}