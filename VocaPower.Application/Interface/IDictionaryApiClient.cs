using VocaPower.Application.Word.Model;
using VocaPower.Domain.Entities;

namespace VocaPower.Application.Interface
{
    public interface IDictionaryApiClient
    {
        LookUpResponse LookUp(string word);
    }
}