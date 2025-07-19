using System.Collections.Generic;

/// <summary>
/// Пул шаров
/// </summary>
public class Pool<TPoolable, TSettings> where TPoolable : IPoolable<TSettings>
{
    private readonly IItemCreator<TPoolable> _creator;
    private readonly Queue<TPoolable> _allItems;
    private readonly List<TPoolable> _activeItems;
    private int _counter;

    public IEnumerable<TPoolable> ActiveItems => _activeItems;

    public Pool(IItemCreator<TPoolable> creator, int capacity = 10)
    {
        _creator = creator;

        _allItems = new Queue<TPoolable>(capacity);
        _activeItems = new List<TPoolable>(capacity);

        FillWithNewElements(capacity);
    }

    /// <summary>
    /// Взять объект из пула
    /// </summary>
    /// <returns>Объект пула</returns>
    public TPoolable GetElement()
    {
        if (_allItems.Count < 1)
        {
            return CreateNewElement();
        }
        return _allItems.Dequeue();
    }

    /// <summary>
    /// Вернуть объект в пул
    /// </summary>
    /// <param name="item">Возвращаемый шар</param>
    public void ReturnElement(TPoolable item)
    {
        item.Deactivate();
        _allItems.Enqueue(item);
    }

    private TPoolable CreateNewElement()
    {
        var item = _creator.Create(_counter++);
        item.Deactivate();
        return item;
    }

    private void FillWithNewElements(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _allItems.Enqueue(CreateNewElement());
        }
    }
}
