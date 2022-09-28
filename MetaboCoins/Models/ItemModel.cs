using System;
using System.Collections.Generic;
using System.Text;

namespace MetaboCoins.Models
{
    public class ItemModel
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
