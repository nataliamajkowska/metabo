using System;
using System.Collections.Generic;
using System.Text;

namespace MetaboCoins.Helpers.Response
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
