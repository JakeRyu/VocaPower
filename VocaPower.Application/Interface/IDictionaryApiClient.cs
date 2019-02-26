using VocaPower.Application.Word.Model;

namespace VocaPower.Application.Interface
{
    public interface IDictionaryApiClient
    {
        LookUpResponse LookUp(string word);
    }
}