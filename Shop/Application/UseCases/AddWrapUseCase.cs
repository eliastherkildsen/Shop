using Shop.Entities;

namespace Shop.Application.UseCases;

public class AddWrapUseCase
{
    
    public Order Order { get; }
    public AddWrapUseCase(List<Wrap> wraps, int wrapIndex)
    {
        
        // validating that least 1 item has been received.
        if (wraps == null || wraps.Count == 0) throw new ArgumentNullException(nameof(wraps));
        
        // validating that the selected item is valid 
        if (wraps.Count <= wrapIndex) throw new IndexOutOfRangeException($"The selected item index is out of range. {wrapIndex}");
        
        Order = wraps[wrapIndex];
        
    }
}