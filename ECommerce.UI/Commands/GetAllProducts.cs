using System.Text;
using ConsoleTables;
using ECommerce.Business;
using ECommerce.Business.Handlers;
using ECommerce.Data.Models;
using MediatR;

namespace ECommerce.UI.Commands;

public class GetAllProductsCommand : ICommand
{
    private IMediator _mediator;
    
    public GetAllProductsCommand(IMediator mediator)
    {
        _mediator = mediator;
    }

    public string Title => "Get all products";

    public void GetArguments() { }

    public async Task Handle()
    {
        var items = await _mediator.Send(new GetAllProductsQuery());

        ConsoleTable
            .From(items)
            .Configure(o =>
            {
                o.EnableCount = true;
                o.NumberAlignment = Alignment.Right;
            })
            .Write(Format.Alternative);
    }
}