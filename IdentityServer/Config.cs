using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission" },
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission" },
            },
            new ApiResource("ResourceBasket")
            {
                Scopes = { "BasketFullPermission" },
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations"),
            new ApiScope("BasketFullPermission", "Full authority for basket operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "KotonVisitorId",
                ClientName = "Koton Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("kotonsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission" }
            },
            new Client
            {
                ClientId = "KotonMemberId",
                ClientName = "Koton Shop Member User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("kotonsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", "BasketFullPermission" }
            }
        };
    }
}
