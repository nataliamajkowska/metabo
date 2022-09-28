namespace MetaboCoins.API.Helpers.Response
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StoreName { get; set; }
        public int PhoneNumber { get; set; }
    }
}
