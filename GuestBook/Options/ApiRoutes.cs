namespace GuestBook.Options
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Notes
        {
            public const string GetAll = Base + "/note";
            public const string Create = Base + "/note";
        }
        
    }
}