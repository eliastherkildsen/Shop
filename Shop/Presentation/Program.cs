using Shop.Application;
using Shop.Entities;
using Shop.Infrastructure;

namespace Shop.Presentation;

class Program
{
    
    private static List<Item> Items;
    private static List<Item> Shipments;
    private static List<Item> Wraps;
    
    private static Item SelectedItem;
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Program has started.....");
        
        // loading items.
        Items = new LoadItemsUseCase(
            new FileItemRepos(@"C:\Users\elias\RiderProjects\Shop\Shop\DATAFOLDER\ITEMS")).ItemsList;
        
        SelectedItem = new PickItemUseCase(Items).PickItem(); 

        // loading shipment options.
        Shipments = new LoadItemsUseCase(
            new FileItemRepos(@"C:\Users\elias\RiderProjects\Shop\Shop\DATAFOLDER\DECORATORS\SHIPMENT")).ItemsList;

        // loading shipment options. 
        Wraps = new LoadItemsUseCase(
            new FileItemRepos("C:\\Users\\elias\\RiderProjects\\Shop\\Shop\\DATAFOLDER\\DECORATORS\\WRAPS")).ItemsList;
        
    }


    
    
}