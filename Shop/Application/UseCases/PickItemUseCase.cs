using Shop.Entities;

namespace Shop.Application.UseCases;

public class PickItemUseCase
{
    
    public Item Item { get; }

    public PickItemUseCase(List<Item> items, int selectedItemIndex)
    {
        // validating that least 1 item has been received.
        if (items == null || items.Count == 0) throw new ArgumentNullException(nameof(items));
        
        // validating that the selected item is valid 
        if (items.Count < selectedItemIndex) throw new ArgumentException("You must select at least one item", nameof(items));
        
        Item = items[selectedItemIndex];
    }
    
}