using System;
using System.Collections.Generic;
using System.Text;

namespace MetaboCoins.Helpers.Response
{
    public class ScanResponse
    {
        public Guid UserId { get; set; }
        public string ProductType { get; set; }
        public string SerialNumber { get; set; }
        public int SkipRecords { get; set; }
    }
}
