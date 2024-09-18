using Shop.Entities;

namespace Shop.Application;

public class PickShipmentUseCase
{

    private Order _order;
    private List<Item> _items;
    
    public PickShipmentUseCase(List<Item> shippingItems, Order orders)
    {
        _order = orders;
        _items = shippingItems;
    }

    public Order PickShipment()
    {
        
        // prompt the user if they want to add a shipping option.
        Console.WriteLine("Do you want shipment? enter 'y' for yes or 'n' for no");

        while (true)
        {
            
            var input = Console.ReadLine().ToUpper();
            if (input == "N")
            {
                return _order;
            }

            if (input == "Y")
            {
                Item selectedShipment = new PickItemUseCase(_items).PickItem();
                
                
                
            }
            
            
        }
        

    }

    
    
    
    
}