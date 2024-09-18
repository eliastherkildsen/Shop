using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Application.UseCases;

public class LoadWrapUseCase
{
    
    public List<Wrap> Wraps { get; }

    public LoadWrapUseCase(IWrapRepos wrapRepos, Order order)
    {
        Wraps = wrapRepos.GetAllWraps(order); 
    }
    
}