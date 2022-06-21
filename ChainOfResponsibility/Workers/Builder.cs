using ChainOfResponsibility.Abstraction;
using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.Workers;

public class Builder : IWorker
{
    public override void Invoke(AbsCommand command)
    {
        if (command.Type == TypeCommand.Build)
        {
            Console.WriteLine($"command executed : {command.Command}");
        }

        base.Invoke(command);
    }
}