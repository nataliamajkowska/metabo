namespace MetaboCoins.API.Model
{
    public class ScanHistoryModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public long SerialNumber { get; set; }
        public int Points { get; set; }
        public DateTime AddDate { get; set; }
        public bool ScanSuccess { get; set; }
    }
}
