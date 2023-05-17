using ECommerce.UI.Commands;

namespace ECommerce.UI.Menu;

public class Menu 
{
    private List<ICommand> _commands;

    public Menu(IEnumerable<ICommand> commands)
    {
        _commands = commands.ToList();
    }

    public async Task Run()
    {
        while (true)
        {
            PrintMenu();
            var result = GetCommand();

            if (!result.IsSuccess)
            {
                Console.WriteLine(result.ErrorMessage);
                continue;
            }

            if (result.IsExit)
            {
                break;
            }

            var command = result.Command!;
            
            command.GetArguments();
            await command.Handle();
        }
    }

    private void PrintMenu()
    {
        var menuText =  _commands
            .Select((command, index) => $"{index + 1}. {command.Title}")
            .Aggregate((a, b) => $"{a} \n{b}");

        var exitCommandText = $"\n{_commands.Count() + 1}. Exit \n";
        
        Console.WriteLine(menuText + exitCommandText);
    }

    private GetCommandResult GetCommand()
    {
        Console.Write("Enter command number: ");
        var commandString = Console.ReadLine();

        var validCommand = Int32.TryParse(commandString, out var commandIndex);

        if (!validCommand || commandIndex < 1 || commandIndex > _commands.Count + 1)
        {
            return GetCommandResult.Fail("Invalid Input!");
        }

        if (commandIndex == _commands.Count + 1)
        {
            return GetCommandResult.Exit();
        }

        return GetCommandResult.Success(_commands.ElementAt(commandIndex - 1));
    }
}