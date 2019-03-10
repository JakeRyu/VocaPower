using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace VocaPower.Application.Events
{
    public class LookUpCalledEventHandler : INotificationHandler<LookUpCalled>
    {
        private readonly IMediator _mediator;

        public LookUpCalledEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public Task Handle(LookUpCalled notification, CancellationToken cancellationToken)
        {
            // save look-up result and user info
            return Task.CompletedTask;
        }
    }
}