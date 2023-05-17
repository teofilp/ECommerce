namespace ECommerce.UI.Commands;

public interface ICommand
{
    void GetArguments() {}
    Task Handle();
    
    string Title { get; }
}