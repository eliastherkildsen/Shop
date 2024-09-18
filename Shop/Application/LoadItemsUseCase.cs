using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Application
{
    public class LoadItemsUseCase
    {
        private readonly IItemsRepos _itemsRepos;
        public List<Item> ItemsList { get; } 

        public LoadItemsUseCase(IItemsRepos itemsRepos)
        {
            _itemsRepos = itemsRepos;
            ItemsList = _itemsRepos.GetAllItems();
        }
        
    }
}
