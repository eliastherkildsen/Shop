using Microsoft.VisualBasic.FileIO;
using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Infrastructure;

public class FileWrapRepos : IWrapRepos
{
    
    private string _filePath;
    private readonly IFileService _fileService = new FileService();
    public List<Wrap> WrapList { get; }

    public FileWrapRepos(string directoryPath)
    {
        _filePath = directoryPath;
    }
    
    public List<Wrap> GetAllWraps(Order order)
    {
        
        // validating that the file exists. 
        if (!_fileService.IsDirectoryAvailable(_filePath)) throw new FileNotFoundException();
        
        // if the directory is empty we will return an empty list of wraps. 
        if (!_fileService.DirectoryContainsFiles(_filePath)) return new List<Wrap>();
        
        var files = _fileService.GetFiles(_filePath);
        var wraps = new List<Wrap>();

        foreach (var file in files)
        {
            wraps.Add(GetWrap(file, order));
        }
        
        return wraps;
        
    }

    private Wrap GetWrap(string path, Order order)
    {
        var text = File.ReadAllText(path);
        var data = text.Split(","); 
            
        // checking if there are more attributes then expected
        if (data.Length != 2) throw new MalformedLineException("There where more attributes then expected. File should be formated properly. name, price");

        // conversing price from string to double.
        double price = double.Parse(data[1]);
            
        return new Wrap(order, data[0], price);
    }

    
}