namespace MetaboCoins.API.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public Guid StoreBranchId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StoreName { get; set; }
        public int PhoneNumber { get; set; }
        public int MetaboCoins { get; set; }
        public int MetaboCoinsForSettlement { get; set; }
        public int MetaboCoinsCleared { get; set; }
        /*
         *   public Guid Id { get; set; } = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709");
        public Guid StoreBranchId { get; set; } = new Guid("662B0228-1234-4C23-8B49-01A698857709");
        public string Login { get; set; } = "Admin";
        public string Password { get; set; } = "Admin12!";
        public string Name { get; set; } = "Jan";
        public string LastName { get; set; } = "Kowalski";
        public string Email { get; set; } = "jan@kowalski.pl";
        public string StoreName { get; set; } = "PA";
        public int PhoneNumber { get; set; } = 234123456;
        public int MetaboCoins { get; set; } = 1600;
        public int MetaboCoinsForSettlement { get; set; } = 700;
        public int MetaboCoinsCleared { get; set; } = 900;
        */
    }
}
