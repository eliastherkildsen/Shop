namespace Shop.Entities
{
    public class Item 
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Item(string id, string description, double price)
        {
            Id = id;
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID - {Id}, Description - {Description}, Price - {Price}";
        }
    }
}
