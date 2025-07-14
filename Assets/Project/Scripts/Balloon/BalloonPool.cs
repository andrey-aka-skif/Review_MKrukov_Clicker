using System.Collections.Generic;

/// <summary>
/// Пул шаров
/// </summary>
public class BalloonPool
{
    private readonly IBalloonCreator _creator;
    private readonly Queue<Balloon> _pool;

    private int _counter;

    public BalloonPool(IBalloonCreator creator, int capacity = 10)
    {
        _creator = creator;

        _pool = new Queue<Balloon>(capacity);

        FillWithNewElements(capacity);
    }

    /// <summary>
    /// Взять шар из пула
    /// </summary>
    /// <returns>Шар</returns>
    public Balloon GetElement()
    {
        if (_pool.Count < 1)
        {
            return CreateNewElement();
        }
        return _pool.Dequeue();
    }

    /// <summary>
    /// Вернуть шар в пул
    /// </summary>
    /// <param name="balloon">Возвращаемый шар</param>
    public void ReturnElement(Balloon balloon)
    {
        balloon.Deactivate();
        _pool.Enqueue(balloon);
    }

    private Balloon CreateNewElement()
    {
        var balloon = _creator.Create(_counter++);
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
