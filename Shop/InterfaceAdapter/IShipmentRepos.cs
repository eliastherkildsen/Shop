using Shop.Entities;

namespace Shop.InterfaceAdapter;

public interface IShipmentRepos
{
    
    List<Shipment> GetAllShipments(Order order);
    
}