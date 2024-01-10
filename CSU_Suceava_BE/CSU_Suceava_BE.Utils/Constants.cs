namespace CSU_Suceava_BE.Utils
{
    public static class Constants
    {
        public static class JWTClaims
        {
            public const string Id = "ID";
            public const string Role = "Role";
            public const string Email = "Email";
        }

        public static class JWTMdl
        {
            public const string SecurityDefinitioAuthorizationType = "oauth2";
            public const string SecurityDefinitionDescription = "Standard Authorization header using the Bearer scheme (\"Bearer {token}\")";
            public const string SecurityDefinitionName = "Authorization";
        }
    }
}