using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace LinhKienDienTu.Localization
{
    public static class LinhKienDienTuLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(LinhKienDienTuConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(LinhKienDienTuLocalizationConfigurer).GetAssembly(),
                        "LinhKienDienTu.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
