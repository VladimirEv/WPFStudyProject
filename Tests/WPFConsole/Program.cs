
// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;
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

static IEnumerable<(string Country, string Province, int[] Counts)> GetData()
{
    var lines = GetDataLines()
        .Skip(1)
        .Select(line => line.Split(','));

    foreach (var row in lines)
    {
        
        var province = row[0].Trim();
        var country_name = row[1].Trim(' ', '"');
 
        var counts = row.Skip(4).Select(s =>
        {
            int.TryParse(s, out int count);
            return count;
        }).ToArray();



yield return (country_name, province, counts);
    }
}

//var client  = new HttpClient();
//var response = client.GetAsync(data_url).Result;
//var csr_str = response.Content.ReadAsStringAsync().Result;
//Console.ReadLine();

//foreach (var data_line in GetDataLines())
//{
//    Console.WriteLine(data_line);
//    Console.ReadLine();
//}

//var dates = GetDates();
//Console.WriteLine(string.Join("\r\n", dates));

var russia_data = GetData().First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));

Console.WriteLine(string.Join("\r\n", GetDates().Zip(russia_data.Counts, (date, count) => $"{date:dd:MM}-{count}")));

Console.ReadLine();
