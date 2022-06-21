using ChainOfResponsibility.Abstraction;
using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.Workers;

public class Driver_One : IWorker
{
    private bool _free;
    public override void Invoke(AbsCommand command)
    {
        if (command.Type == TypeCommand.Drive && _free)
        {
            Console.WriteLine($"command executed : {command.Command}");
        }

        base.Invoke(command);
    }
}