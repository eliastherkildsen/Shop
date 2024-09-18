namespace Shop.Entities
{
    public class Item : Order
    {
        public string Id { get; set; }
        private string _description;
        private double _price;
        
        public Item(string id, string description, double price)
        {
            Id = id;
            _description = description;
            _price = price;
        }


        public override double Price()
        {
            return _price;
        }

        public override string Description()
        {
            return _description;
        }
        
        public override string ToString()
        {
            return $"ID - {Id}, Description - {_description}, Price - {_price}";
        }
        
        
    }
}
