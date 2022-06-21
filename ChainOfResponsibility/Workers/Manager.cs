using ChainOfResponsibility.Abstraction;
using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.Workers;

public class Manager : IWorker
{
    public override void Invoke(AbsCommand command)
    {
        if (command.Type == TypeCommand.Offer || command.Type == TypeCommand.Order)
        {
            Console.WriteLine($"command executed : {command.Command}");
        }

        base.Invoke(command);
    }
}