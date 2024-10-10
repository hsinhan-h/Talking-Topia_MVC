namespace Api.Settings
{
    public class JwtSettings
    {
        public const string Key = "JwtSettings";
        public string Issuer { get; set; }
        public string SignKey { get; set; }
    }
}
