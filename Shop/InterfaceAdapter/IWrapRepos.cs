using Shop.Entities;

namespace Shop.InterfaceAdapter;

public interface IWrapRepos
{
    List<Wrap> GetAllWraps(Order order);
    
}