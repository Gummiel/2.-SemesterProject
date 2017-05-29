namespace BestillingApp.Singleton
{
    internal class LoginSingleton
    {
        private static LoginSingleton _instance;

        private LoginSingleton()
        {
            Name = "";
            Email = "";
        }

        public static string Name { get; set; }
        public static string Email { get; set; }


        public static LoginSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginSingleton();
                return _instance;
            }
        }
    }
}