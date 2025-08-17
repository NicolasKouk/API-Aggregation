using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

string unite_jsons(List<string> res) {
    if (res.Count == 0) {
        return "error";
    }
    if (res.Count == 1) {
        return res[0];
    }

    StringBuilder s = new StringBuilder("[{");
    for (int i = 0; i < res.Count; i++)
    {
        s.Append(res[i]);
        s.Append(",\n");
    }
    s.Remove(s.Length - 2, 2);
    s.Append("\n}]");

    return s.ToString();
}

app.MapGet("/", (decimal? latitude=0, decimal? longitude=0, string? q = "") =>
{

    var results = new List<string>();

    System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,is_day,rain");
    webrequest.Method = "GET";
    using (WebResponse response = webrequest.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            results.Add(reader.ReadToEnd());
        }
    }

    webrequest = (HttpWebRequest)System.Net.WebRequest.Create($"https://api.spaceflightnewsapi.net/v4/articles/?event=100&has_event=true");
    webrequest.Method = "GET";
    using (WebResponse response = webrequest.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            results.Add(reader.ReadToEnd());
        }
    }

    webrequest = (HttpWebRequest)System.Net.WebRequest.Create($"https://openlibrary.org/search.json?q=the+lord+of+the+rings");
    webrequest.Method = "GET";
    using (WebResponse response = webrequest.GetResponse())
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            results.Add(reader.ReadToEnd());
        }
    }

    return unite_jsons(results);


});

app.Run();
