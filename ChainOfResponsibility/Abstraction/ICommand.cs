using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.Abstraction;

public abstract class AbsCommand
{
    public TypeCommand Type { get; set; }
    
    public string Command { get; set; }
}