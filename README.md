# API Aggregation 

## API description

This repository contains a webservice that was built via ASP.NET. The webapi calls 3 other external APIs and gathers data, in order to display everything. 

At first, we call the API of a Weather Forecast service, named Open-Meteo. We choose to acquire the current temperature, humidity, and amount of rain at a given location. The location is specified via parameters that do not explicitly form a path, but they instead are called as parameters from the link. In this API, we need the parameters `latitude` and `longitude`, therefore we call: 
```
<root_path>?latitude={l1}&longitude={l2}
```

The second API is a news webservice, named Spaceflight News, that manages articles and blogs about international space station and space operations. 

The third API is a virtual book library, named Open Library. The user searches for a query and the webservice returns the results of the query, i.e. the relevant books and related info on them. We use a similar way of calling the API and passing on the parameters:  
```
<root_path>?q={query}
```

## Aggregation

After extrapolating the data, we aggregate them. Since we work with JSONs transformed to strings, we concatinate the strings accordingly, so that the whole structure can still be functional as a JSON after suitable transformations. Another way of performing this aggregation could include deserializing the JSONs into objects, connecting them together and then serializing them again, so that they can form one single JSON. 

## Notes

- ALl procedures are performed within Program.cs. While we could have used a controller file, the small size of the project allowed us to work more flexibly with a single code file.
- The `requests.http` file contains requests that can be used for testing the webapi and exploring its capabilities.
- The geographical coordinates in the `requests.http` file correspond to the coordinates of Chalandri, Athens, therefore the returned weather is the current weather in Chalandri, Athens. 
