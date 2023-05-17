using MediatR;

namespace ECommerce.UI.Commands;

using MediatorCommands = Business.Handlers;

public class PingCommand : ICommand
{
    private IMediator _mediator;

    public PingCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle()
    {
        await _mediator.Send(new MediatorCommands.PingCommand());
    }

    public string Title => "Ping RabbitMQ";
}