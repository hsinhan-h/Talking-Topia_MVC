namespace Infrastructure
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}