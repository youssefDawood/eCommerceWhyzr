using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace eCommerceWhyzr.Localization
{
    public static class eCommerceWhyzrLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(eCommerceWhyzrConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(eCommerceWhyzrLocalizationConfigurer).GetAssembly(),
                        "eCommerceWhyzr.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
