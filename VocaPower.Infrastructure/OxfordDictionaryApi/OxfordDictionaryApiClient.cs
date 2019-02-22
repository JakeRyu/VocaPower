using AutoMapper;
using RestSharp;
using VocaPower.Application.Interface;
using VocaPower.Domain.Entities;
using VocaPower.Infrastructure.Infrastructure;

namespace VocaPower.Infrastructure.OxfordDictionaryApi
{
    public class OxfordDictionaryApiClient : IDictionaryApiClient
    {
        public void SearchEntry()
        {
            var client = new RestClient("https://od-api.oxforddictionaries.com/api/v1");
// client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("entries/en/{id}", Method.GET);
//            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "ace"); // replaces matching token in request.Resource

// easily add HTTP Headers
            request.AddHeader("app_Id", "88c0940f");
            request.AddHeader("app_key", "0c1cd77bfda44601c3808686dbf24e1e");


// execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

//// or automatically deserialize result
//// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
//            RestResponse<Person> response2 = client.Execute<Person>(request);
//            var name = response2.Data.Name;
//
//// easy async support
//            client.ExecuteAsync(request, responseA => { Console.WriteLine(responseA.Content); });
//
//// async with deserialization
//            var asyncHandle =
//                client.ExecuteAsync<Person>(request, responseB => { Console.WriteLine(responseB.Data.Name); });
//
//// abort the request on demand
//            asyncHandle.Abort();
        }

        public WordEntry SearchEntry(string word)
        {
            var client = new RestClient("https://od-api.oxforddictionaries.com/api/v1");
// client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("entries/en/{id}", Method.GET);
//            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", word); // replaces matching token in request.Resource

// easily add HTTP Headers
            request.AddHeader("app_Id", "88c0940f");
            request.AddHeader("app_key", "0c1cd77bfda44601c3808686dbf24e1e");


// execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            return null;

        }

        IMapper _mapper;

        public OxfordDictionaryApiClient()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<InfrastructureProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public WordEntry LookUp(string word)
        {
            var client = new RestClient("https://od-api.oxforddictionaries.com/api/v1");

            var request = new RestRequest("entries/en/{id}", Method.GET);
            request.AddUrlSegment("id", word); // replaces matching token in request.Resource

            request.AddHeader("app_Id", "88c0940f");
            request.AddHeader("app_key", "0c1cd77bfda44601c3808686dbf24e1e");


            var response = client.Execute<OxfordDictionaryLookUpResponse>(request);
//            var wordEntry = _mapper.Map<WordEntry>(response.Data.Results[0]);
//
//            return wordEntry;
            var wordEntry = new WordEntry(word);
            response.Data.Results[0].LexicalEntries.ForEach(e => 
                wordEntry.LexicalEntries.Add(_mapper.Map<LexicalEntry>(e))
            );

            return wordEntry;
        }
    }
}