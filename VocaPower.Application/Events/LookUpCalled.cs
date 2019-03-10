using MediatR;
using VocaPower.Application.Word.Command;
using VocaPower.Application.Word.Model;

namespace VocaPower.Application.Events
{
    public class LookUpCalled : INotification
    {
        
        public LookUpResponse Response { get; }

        public LookUpCalled(LookUpResponse response)
        {
            Response = response;
        }
    }
}