namespace MetaboCoins.API.Model
{
    public class StoreBranchModel
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; }
        public int TurnoverThreshold { get; set; }
        public int Turnover { get; set; }
    }
}
