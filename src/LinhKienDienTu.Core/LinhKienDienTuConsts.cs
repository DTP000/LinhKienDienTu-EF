using LinhKienDienTu.Debugging;

namespace LinhKienDienTu
{
    public class LinhKienDienTuConsts
    {
        public const string LocalizationSourceName = "LinhKienDienTu";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "9232ff37357a4e0f8e615b6544a5d959";
    }
}
