using ChainOfResponsibility.Abstraction;
using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.Workers;

public class Driver_Two : IWorker
{
    private bool _free = true;
    public override void Invoke(AbsCommand command)
    {
        if (command.Type == TypeCommand.Drive && _free)
        {
            Console.WriteLine($"command executed : {command.Command}");
        }

        base.Invoke(command);
    }
}