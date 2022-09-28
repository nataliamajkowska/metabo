namespace MetaboCoins.API.Helpers.Response
{
    public class ScanItemResponse
    {
        public int ProductId { get; set; }
        public int Points { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool ScanSuccess { get; set; }
    }
}
