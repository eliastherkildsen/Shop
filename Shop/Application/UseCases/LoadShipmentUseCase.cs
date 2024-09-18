using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Application.UseCases;

public class LoadShipmentUseCase
{
    public List<Shipment> shipments { get; }

    public LoadShipmentUseCase(IShipmentRepos shipmentRepos, Order order)
    {
        shipments = shipmentRepos.GetAllShipments(order); 
    }
}