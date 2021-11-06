using System.Collections.Generic;

public class BalloonPool
{
    private readonly IBalloonCreator _creator;
    private readonly Queue<Balloon> _pool;

    public BalloonPool(IBalloonCreator creator, int capacity = 10)
    {
        _creator = creator;

        _pool = new Queue<Balloon>(capacity);

        FillWithNewElements(capacity);
    }

    public Balloon GetElement()
    {
        if (_pool.Count < 1)
        {
            return CreateNewElement();
        }
        return _pool.Dequeue();
    }

    public void ReturnElement(Balloon balloon)
    {
        balloon.Deactivate();
        _pool.Enqueue(balloon);
    }

    private Balloon CreateNewElement()
    {
        Balloon balloon = _creator.Create();
        balloon.Deactivate();
        return balloon;
    }

    private void FillWithNewElements(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _pool.Enqueue(CreateNewElement());
        }
    }
}