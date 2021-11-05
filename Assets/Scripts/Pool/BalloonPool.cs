using System.Collections.Generic;

public class BalloonPool
{
    private readonly IPoolObjectCreator<Balloon> _creator;
    private readonly Queue<Balloon> _pool;

    public BalloonPool(IPoolObjectCreator<Balloon> creator, int capacity = 10)
    {
        _creator = creator;

        _pool = new Queue<Balloon>(capacity);

        FillWithNewElements(capacity);
    }

    public Balloon GetElement()
    {
        if (_pool.Count < 1)
        {
            CreateNewElement();
        }
        return _pool.Dequeue();
    }

    public void ReturnElement(Balloon balloon)
    {
        balloon.ResetState();
        _pool.Enqueue(balloon);
    }

    private void CreateNewElement()
    {
        Balloon balloon = _creator.Create();
        balloon.ResetState();
        _pool.Enqueue(balloon);
    }

    public void FillWithNewElements(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreateNewElement();
        }
    }
}