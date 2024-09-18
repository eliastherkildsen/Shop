using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Infrastructure;

public class MemoryItemRepos : IItemsRepos
{
    public List<Item> GetAllItems()
    {

        List<Item> items =
        [
            
            new Item("A32", "24k Gold chain", 4500),
            new Item("B68", "12k Gold chain", 2450),
            new Item("C8", "6k Gold chain", 1500),
            
        ]; 
        
        return items;


    }
}