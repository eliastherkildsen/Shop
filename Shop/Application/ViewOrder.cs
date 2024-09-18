using Shop.Entities;

namespace Shop.Application;

public class ViewOrder
{
    private readonly Order _order;

    public ViewOrder(Order order)
    {
        this._order = order;
    }

    public void viewOrder()
    {
        Console.Write($"Your order\n{_order}\n");
    }
    
}