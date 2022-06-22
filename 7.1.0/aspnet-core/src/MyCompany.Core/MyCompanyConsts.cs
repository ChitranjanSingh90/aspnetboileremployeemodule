using MyCompany.Debugging;

namespace MyCompany
{
    public class MyCompanyConsts
    {
        public const string LocalizationSourceName = "MyCompany";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "cf58e80f4e0b4547b9c8de47c396dce1";
    }
}
