using RestSharp;
using VocaPower.Application.Interface;
using VocaPower.Application.Word.Model;

namespace VocaPower.Infrastructure.OxfordDictionaryApi
{
    public class OxfordDictionaryApiClient : IDictionaryApiClient
    {
        public LookUpResponse LookUp(string word)
        {
            var client = new RestClient("https://od-api.oxforddictionaries.com/api/v1");

            var request = new RestRequest("entries/en/{id}", Method.GET);
            request.AddUrlSegment("id", word); // replaces matching token in request.Resource

            request.AddHeader("app_Id", "88c0940f");
            request.AddHeader("app_key", "0c1cd77bfda44601c3808686dbf24e1e");


            var response =  client.Execute<LookUpResponse>(request);

            return response.Data;
        }
    }
}