
// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.CompilerServices;

const string data_url = 
@"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

static async Task<Stream> GetDateStream() //формирует поток данных
{
    var client = new HttpClient();
    var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
    return await response.Content.ReadAsStreamAsync();
}

static IEnumerable<string> GetDataLines() //разбивает поток данных на строки
{
    using var data_stream = GetDateStream().Result;
    using var data_reader = new StreamReader(data_stream);

    while(!data_reader.EndOfStream)
    {
        var line = data_reader.ReadLine();
        if (string.IsNullOrWhiteSpace(line)) continue;
        yield return line;
    }
}

static DateTime[] GetDates()=> GetDataLines()
    .First()
    .Split(',')
    .Skip(4)
    .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
    .ToArray();

//var client  = new HttpClient();
//var response = client.GetAsync(data_url).Result;
//var csr_str = response.Content.ReadAsStringAsync().Result;
//Console.ReadLine();

//foreach (var data_line in GetDataLines())
//{
//    Console.WriteLine(data_line);
//    Console.ReadLine();
//}

var dates = GetDates();

Console.WriteLine(string.Join("\r\n", dates));

Console.ReadLine();
