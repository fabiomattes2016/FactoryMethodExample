namespace FactoryMethodExample.Models
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }

        public override string ToString()
        {
            return string.Format($"access_token: {access_token}\nrefresh_token: {refresh_token}");
        }
    }
}
