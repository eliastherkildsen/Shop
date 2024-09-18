using System.Collections;
using System.Diagnostics;
using Shop.Application;
using Shop.Application.UseCases;
using Shop.Entities;
using Shop.Infrastructure;

namespace Shop.Presentation;

class Program
{
    
    private static FileItemRepos _fileItemRepos = 
        new FileItemRepos(@"C:\Users\elias\Desktop\Shop\Shop\DATAFOLDER\ITEMS");

    private static FileWrapRepos _fileWrapRepos =
        new FileWrapRepos(@"C:\Users\elias\Desktop\Shop\Shop\DATAFOLDER\DECORATORS\WRAPS"); 
    
    private static FileShipmentRepos _fileShipmentRepos = 
        new FileShipmentRepos(@"C:\Users\elias\Desktop\Shop\Shop\DATAFOLDER\DECORATORS\SHIPMENT");
    
    
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Program has started.....");
        
        Console.WriteLine("Here is a list of all the items i the shop. ");
        new ShowAllItemsUseCase(_fileItemRepos); 
        
        Console.WriteLine("Would you like to create an order");
        if (!PromptUserSelectBool()) return; // Exits the application if the user does not want to place an order.  
        
        // loading items into memory.
        var items = new LoadItemsUseCase(_fileItemRepos).ItemsList;
        
        // prompt the user to select an item. 
        Order order = new PickItemUseCase(items, PromptUserSelectIndex(items)).Item;
        
        // loading wraps into memory. 
        var wrapOptions = new LoadWrapUseCase(_fileWrapRepos, order).Wraps;
        
        // prompt the user to select wraping. 
        Console.WriteLine("Would you like to Wrap the order?");
        if (PromptUserSelectBool())
        {
            order = new AddWrapUseCase(wrapOptions, PromptUserSelectIndex(wrapOptions)).Order;
            
        }
        
        // load shipment into memory. 
        var shipmentOptions = new LoadShipmentUseCase(_fileShipmentRepos, order).shipments;
        
        // prompt user to select shipment. 
        Console.WriteLine("Would you like the item to be shipped?");
        if (PromptUserSelectBool())
        {
            order = new AddShipmentUseCase(shipmentOptions, PromptUserSelectIndex(wrapOptions)).Order; 
        }

        // displaying the order to the user. 
        new ViewOrderUseCase(order); 

    }
    
    /// <summary>
    /// Method for prompting the user to select a index of a list. 
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private static int PromptUserSelectIndex(IList list)
    {

        while (true)
        {
            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"[{i}]: {list[i]}");
            }
            
            // instructing the user. 
            Console.WriteLine("Please select a item from the list, by entering the corresponding number");
            
            // wating for user input. 
            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result >= 0 && result < list.Count)
                {
                    return result; 
                }
            }
            
            Console.WriteLine("Please enter a valid number"); 
            
            
            
        }
        
        
    }

    
    /// <summary>
    /// Method for prompting the user to select yes or no. 
    /// </summary>
    /// <returns></returns>
    private static bool PromptUserSelectBool()
    {
        while (true)
        {
            Console.WriteLine("Enter Y for yes or N for no");
            
            var input = Console.ReadLine();
            
            if (input?.ToUpper() == "Y") return true; 
            if (input?.ToUpper() == "N") return false; 
            
            // if none of the above returns are invoked the user must have entered an unexpected value. 
            Console.WriteLine($"Please try again. The value entered is incorrect. Value entered: {input}");
                
        }
    } 
    
}