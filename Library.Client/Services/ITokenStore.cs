﻿namespace Library.Client.Services
{
    public interface ITokenStore
    {
        string GetToken();
        
        void SetToken(string token);
    }
}