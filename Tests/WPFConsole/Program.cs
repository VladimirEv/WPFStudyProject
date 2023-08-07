
// See https://aka.ms/new-console-template for more information

const string data_url = 
@"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

var client  = new HttpClient();

var response = client.GetAsync(data_url).Result;

var csr_str = response.Content.ReadAsStringAsync().Result;

Console.ReadLine();
