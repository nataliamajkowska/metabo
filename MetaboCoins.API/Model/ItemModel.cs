namespace MetaboCoins.API.Model
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int Points { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
