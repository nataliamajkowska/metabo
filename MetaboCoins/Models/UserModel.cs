using System;
using System.Collections.Generic;
using System.Text;

namespace MetaboCoins.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public Guid StoreBranchId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StoreName { get; set; }
        public int PhoneNumber { get; set; }
        public int MetaboCoins { get; set; }
        public int MetaboCoinsForSettlement { get; set; }
        public int MetaboCoinsCleared { get; set; }
    }
}
