using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Application.UseCases
{
    public class LoadItemsUseCase
    {
        public List<Item> ItemsList { get; } 

        public LoadItemsUseCase(IItemsRepos itemsRepos)
        {
            ItemsList = itemsRepos.GetAllItems();
        }
        
    }
}
