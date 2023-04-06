using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using LinhKienDienTu.Authorization;

namespace LinhKienDienTu.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class LinhKienDienTuNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Categories,
                        L("Category"),
                        url: "Category",
                        icon: "fas fa-list",
                        requiresAuthentication: true
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Products,
                        L("Product"),
                        url: "Product",
                        icon: "fas fa-archive",
                        requiresAuthentication: true
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Order,
                        L("Order"),
                        url: "Order",
                        icon: "fas fa-shopping-cart",
                        requiresAuthentication: true
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                )
                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LinhKienDienTuConsts.LocalizationSourceName);
        }
    }
}