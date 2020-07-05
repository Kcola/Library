using Library.Shared;

namespace Library.Client.Services
{
    public class TokenStore: ITokenStore
    {
        private readonly Token _token;

        public TokenStore()
        {
            _token = new Token();
        } 
        public string GetToken()
        {
            return _token.Jwt;
        }

        public void SetToken(string token)
        {
            _token.Jwt = token;
        }
    }
}