using System.Diagnostics;
using Shop.Entities;

namespace Shop.Application;

public class PickItemUseCase
{
    
    private List<Item> _items;
    public PickItemUseCase(List<Item> items)
    {
        // validating that least 1 item has been received.
        if (items == null || items.Count == 0) throw new ArgumentNullException(nameof(items));
        
        this._items = items;
    }

    public Item PickItem()
    {

        for (int i = 0; i < _items.Count; i++)
        {
            
            // displaying each item to the user. 
            Console.WriteLine($" [{i}]: {_items[i]}]");
            
        }

        while (true)
        {
            // propt the user to select an item. 
            Console.WriteLine("Please select an item by entering its number: ");
            
            // wating for user to pick an item. 
            var input = Console.ReadLine();
            if (int.TryParse(input, out int index))
            {
                if (index >= 0 && index < _items.Count)
                {
                    return _items[index];    
                }
                
            }
            
            // if input does not match an item propt the user to try again. 
            Console.WriteLine("Please enter a valid number: ");
        }


    }
    
    
}