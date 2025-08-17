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

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    //return "Hello Woooorld!";

    System.Net.HttpWebRequest webrequest = (HttpWebRequest)System.Net.WebRequest.Create("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,relative_humidity_2m,is_day,rain");
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
