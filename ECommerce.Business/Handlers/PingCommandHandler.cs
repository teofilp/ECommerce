using ECommerce.Contracts;
using MassTransit;
using MediatR;

namespace ECommerce.Business.Handlers;

public class PingCommand : IRequest<bool>
{
    
}

public class PingCommandHandler : IRequestHandler<PingCommand, bool>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public PingCommandHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task<bool> Handle(PingCommand request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(new Ping(), cancellationToken);

        return true;
    }
}