namespace MovieNotice.API.Settings
{
    public class AuthenitactionSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }
        public string TMDbAuthKey { get; set; }
    }
}
