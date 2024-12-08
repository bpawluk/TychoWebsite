namespace TychoWebsite.Store.Core;

internal class Item(int id, string name, decimal price)
{
    public int Id { get; private set; } = id;

    public string Name { get; private set; } = name;

    public decimal Price { get; private set; } = price;
}