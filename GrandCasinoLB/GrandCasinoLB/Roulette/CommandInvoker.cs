using System.Windows.Input;

public class CommandInvoker
{
    private List<ICommand> commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void ExecuteCommands(object? parameter)
    {
        foreach(var command in commands)
        {
            command.Execute(parameter);
        }

        commands.Clear();
    }
}