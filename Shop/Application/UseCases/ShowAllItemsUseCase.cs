using System.Diagnostics;
using Shop.InterfaceAdapter;

namespace Shop.Application.UseCases;

public class ShowAllItemsUseCase
{
    public ShowAllItemsUseCase(IItemsRepos itemsRepos)
    {

        foreach (var item in itemsRepos.GetAllItems())
        {
            Console.WriteLine(item);
        }
        
    }
}