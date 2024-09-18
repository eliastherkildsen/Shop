using Microsoft.VisualBasic.FileIO;
using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Infrastructure;

public class FileShipmentRepos : IShipmentRepos
{
    private readonly IFileService _fileService = new FileService();
    private string _directoryPath;
    
    public FileShipmentRepos(string directoryPath)
    {
        _directoryPath = directoryPath;
    }
    
    public List<Shipment> GetAllShipments(Order order)
    {
        
        // validating that the file exists. 
        if (!_fileService.IsDirectoryAvailable(_directoryPath)) throw new FileNotFoundException();
        
        // if the directory is empty we will return an empty list of shipments. 
        if (!_fileService.DirectoryContainsFiles(_directoryPath)) return new List<Shipment>();
        
        var files = _fileService.GetFiles(_directoryPath);
        var shipments = new List<Shipment>();

        foreach (var file in files)
        {
            shipments.Add(GetShipment(file, order));
        }
        
        return shipments;
        
    }

    private Shipment GetShipment(string path, Order order)
    {
        var text = File.ReadAllText(path);
        var data = text.Split(","); 
            
        // checking if there are more attributes then expected
        if (data.Length != 2) throw new MalformedLineException("There where more attributes then expected. File should be formated properly. name, price");

        // conversing price from string to double.
        double price = double.Parse(data[1]);
            
        return new Shipment(order, price, data[0]);
    }
}