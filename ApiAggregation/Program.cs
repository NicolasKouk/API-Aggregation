using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}


app.MapGet("/", (decimal? latitude=0, decimal? longitude=0, string? q = "") =>
{

    // System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create($"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,is_day,rain");
    // webrequest.Method = "GET";
    // string result;
    // using (WebResponse response = webrequest.GetResponse())
    // {
    //     using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    //     {
    //         result = reader.ReadToEnd();
    //         return result;
    //     }
    // }

    // System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create($"https://api.spaceflightnewsapi.net/v4/articles/?event=100&has_event=true");
    // webrequest.Method = "GET";
    // string result;
    // using (WebResponse response = webrequest.GetResponse())
    // {
    //     using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    //     {
    //         result = reader.ReadToEnd();
    //         return result;
    //     }
    // }

    System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create($"https://openlibrary.org/search.json?q=the+lord+of+the+rings");
    webrequest.Method = "GET";
    string result;
    using (WebResponse response = webrequest.GetResponse()) 
    {
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            result = reader.ReadToEnd();
            return result;
        }
    }


});

app.Run();
