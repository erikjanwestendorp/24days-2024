﻿namespace _24Days.Configuration;

public class AppSettings
{
    public class SecretManager
    {
        public string ProjectId { get; set; } = string.Empty;
        public string CredentialsPath { get; set; } = string.Empty;
    }
}
