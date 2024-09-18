namespace Shop.Entities;

public class Shipment : OrderDecorator
{

    private readonly double _price; 
    private readonly string _description; 
    
    public Shipment(Order order, double price, string description) : base(order)
    {
        _price = price;
        _description = description;
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
        return $" Shipment: {_description} | Price: {_price}";
    }
}