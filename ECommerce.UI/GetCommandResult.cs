using ECommerce.UI.Commands;

namespace ECommerce.UI;

public class GetCommandResult
{
    public ICommand? Command { get; set; }
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    
    public bool IsExit { get; set; }

    public static GetCommandResult Success(ICommand command) => new()
    {
        IsSuccess = true,
        Command = command
    };

    public static GetCommandResult Fail(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage
    };

    public static GetCommandResult Exit() => new()
    {
        IsSuccess = true,
        IsExit = true
    };
}