namespace ChainOfResponsibility.Abstraction;

public abstract class IWorker
{
    private IWorker _nextWorker;

    public IWorker()
    {
        _nextWorker = null;
    }

    public IWorker SetNextMonitor(IWorker worker)
    {
        _nextWorker = worker;

        return worker;
    }

    public virtual void Invoke(AbsCommand command)
    {
        if (_nextWorker is null)
            return;
        else
            _nextWorker.Invoke(command);
    }
}