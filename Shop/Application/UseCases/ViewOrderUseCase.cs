using Shop.Entities;

namespace Shop.Application;

public class ViewOrderUseCase
{
    public ViewOrderUseCase(Order order)
    {
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine($"Order price: {order.Price()}");
        Console.WriteLine($"Order description: {order.Description()}");
        Console.WriteLine("-------------------------------------------------------------------");
    }
}