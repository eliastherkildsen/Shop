namespace Shop.Entities;

public abstract class OrderDecorator : Order
{
    protected Order Order;

    protected OrderDecorator(Order order)
    {
        this.Order = order;
    }
    
}