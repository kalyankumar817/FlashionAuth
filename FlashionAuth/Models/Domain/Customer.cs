namespace FlashionAuth.Models.Domain
{
    public class Logindata
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class Signupdata
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
