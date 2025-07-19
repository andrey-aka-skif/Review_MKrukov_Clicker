using System;

public interface IEffect
{
    event Action<IEffect> Completed;

    void Run();
}
