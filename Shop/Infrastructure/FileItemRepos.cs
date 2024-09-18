using Microsoft.VisualBasic.FileIO;
using Shop.Entities;
using Shop.InterfaceAdapter;

namespace Shop.Infrastructure
{
    class FileItemRepos : IItemsRepos
    {
        private readonly string _dirPath;
        private readonly FileService _fileService;
        
        
        public FileItemRepos(string path) 
        {
            _dirPath = path;
            _fileService = new FileService();
        }
        
        public List<Item> GetAllItems()
        {
            
            // validating the path
            if (!_fileService.IsDirectoryAvailable(_dirPath)) throw new DirectoryNotFoundException();
            
            // if the directory does not contain any files we will return an empty list. 
            if (!_fileService.DirectoryContainsFiles(_dirPath)) return new List<Item>();
            
            var files = _fileService.GetFiles(_dirPath);
            var items = new List<Item>();
            
            foreach (var file in files)
            {
                items.Add(GetItemFromPath(file));
            }
            
            return items;  
        }

        /// <summary>
        /// Method for converting a files content into a item obj.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="MalformedLineException"> thrown if the file does not match the expected format CSV, with 3 values </exception>
        private Item GetItemFromPath(string path)
        {
            var text = File.ReadAllText(path);
            var data = text.Split(","); 
            
            // checking if there are more attributes then expected
            if (data.Length != 3) throw new MalformedLineException("There where more attributes then expected. File should be formated properly. with ID, name, price");

            // conversing price from string to double.
            double price = double.Parse(data[2]);
            
            return new Item(data[0], data[1], price);
            
        }

        
        
    }
}
