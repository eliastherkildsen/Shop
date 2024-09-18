namespace Shop.Entities;

public class Wrap : OrderDecorator
{
    
    private readonly string _description;
    private readonly double _price;

    public Wrap(Order order, string description, double price) : base(order)
    {
        _description = description;
        _price = price;
    }

    public override double Price()
    {
        return Order.Price() + _price;
    }

    public override string Description()
    {
        return Order.Description() + ", " + _description;
    }

    public override string ToString()
    {
        return $" Wrap: {_description} | Price: {_price}";
    }
}