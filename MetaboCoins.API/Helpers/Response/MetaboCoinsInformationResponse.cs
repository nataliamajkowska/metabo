namespace MetaboCoins.API.Helpers.Response
{
    public class MetaboCoinsInformationResponse
    {
        public int MetaboCoins { get; set; }
        public int MetaboCoinsForSettlement { get; set; }
        public int MetaboCoinsCleared { get; set; }
        public int TurnoverThreshold { get; set; }
        public int Turnover { get; set; }
    }
}
