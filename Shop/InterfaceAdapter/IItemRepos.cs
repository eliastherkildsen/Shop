using Shop.Entities;

namespace Shop.InterfaceAdapter
{
    public interface IItemsRepos
    {
        List<Item> GetAllItems();
    }
}
