using Shop.Entities;

namespace Shop.Application.UseCases;

public class AddShipmentUseCase
{

    public Order Order { get; }
    
    public AddShipmentUseCase(List<Shipment> shipments, int shipmentIndex)
    {
        
        // validating that least 1 shipment has been received.
        if (shipments == null ||shipments.Count == 0) throw new ArgumentNullException(nameof(shipments));
        
        // validating that the selected item is valid 
        if (shipments.Count <= shipmentIndex) throw new IndexOutOfRangeException($"The selected item index is out of range. {shipmentIndex}");
        
        Order = shipments[shipmentIndex];
        
    }
    
}
