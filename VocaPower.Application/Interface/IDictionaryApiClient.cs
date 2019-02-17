using VocaPower.Domain.Entities;

namespace VocaPower.Application.Interface
{
    public interface IDictionaryApiClient
    {
        WordEntry LookUp(string word);
    }
}