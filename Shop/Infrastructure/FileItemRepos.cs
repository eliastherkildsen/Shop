using Microsoft.VisualBasic.FileIO;
using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Infrastructure
{
    class FileItemRepos : IItemsRepos
    {
        private readonly string _dirPath;
        private string[] _files;
        // path to folder containing items reprecented as a .txt 
        public FileItemRepos(string path) 
        {
            _dirPath = path;
        }
        
        public List<Item> GetAllItems()
        {
            
            // validating that the file exists. 
            if (!ValidateFileExists(_dirPath)) throw new FileNotFoundException();
            
            // fetching files in the directory
            _files = FetchFilesInDirectory();
            if (_files.Length == 0) throw new FileNotFoundException();
            
            List<Item> items = new List<Item>();
            
            foreach (var file in _files)
            {
                items.Add(GetItemFromPath(file)); 
            }
            
            
            return items;
        }

        private bool ValidateFileExists(string filePath)
        {
            bool directoryExists = Directory.Exists(filePath);
            Console.WriteLine($"[FileItemRepos] directory exists: {directoryExists} ad {filePath} ]");
            return directoryExists;
        }

        private string[] FetchFilesInDirectory()
        {
            return Directory.GetFiles(_dirPath);
        }

        private Item GetItemFromPath(string path)
        {
            Item item = null;
            
            // validate that the file exists. 
            if (!File.Exists(path)) throw new FileNotFoundException();
            
            string text = File.ReadAllText(path);
            string[] data = text.Split(","); 
            
            // checking if there are more attributes then expected
            if (data.Length != 3) throw new MalformedLineException("There where more attributes then exspected. File should be formated properly. with ID, name, price");

            // convering price from string to double.
            double price = double.Parse(data[2]);
            
            return new Item(data[0], data[1], price);
            
        }

        
        
    }
}
