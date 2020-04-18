using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechnoTent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Start of Admin Part

            routes.MapRoute(
               name: "admin/login",
               url: "admin/login",
               defaults: new { controller = "Admin", action = "Login" }
            );

            routes.MapRoute(
              name: "admin",
              url: "admin",
              defaults: new { controller = "Admin", action = "Index" }
           );

            routes.MapRoute(
               name: "admin/logout",
               url: "admin/logout",
               defaults: new { controller = "Admin", action = "Logout" }
            );

            routes.MapRoute(
               name: "admin/mainImages",
               url: "admin/mainImages",
               defaults: new { controller = "AdminMainImages", action = "Index" }
            );

            routes.MapRoute(
               name: "admin/categories",
               url: "admin/categories",
               defaults: new { controller = "AdminCategory", action = "Index" }
            );

            routes.MapRoute(
               name: "admin/category/add",
               url: "admin/category/add",
               defaults: new { controller = "AdminCategory", action = "AddCategory" }
            );

            routes.MapRoute(
               name: "admin/category/edit",
               url: "admin/category/edit/{categoryId}",
               defaults: new { controller = "AdminCategory", action = "EditCategory" }
            );

            routes.MapRoute(
               name: "admin/subCategory/add",
               url: "admin/subCategory/add",
               defaults: new { controller = "AdminCategory", action = "AddSubCategory" }
            );

            routes.MapRoute(
               name: "admin/subCategory/edit",
               url: "admin/subCategory/edit/{subCategoryId}",
               defaults: new { controller = "AdminCategory", action = "EditSubCategory" }
            );

            routes.MapRoute(
               name: "admin/items",
               url: "admin/items",
               defaults: new { controller = "AdminItems", action = "Index" }
            );

            routes.MapRoute(
               name: "admin/items/category",
               url: "admin/items/{category}",
               defaults: new { controller = "AdminItems", action = "GetItemsByCategory" }
            );

            //routes.MapRoute(
            //   name: "admin/items/deleteImage",
            //   url: "admin/items/deleteImage",
            //   defaults: new { controller = "AdminItems", action = "DeleteImage" }
            //);

            routes.MapRoute(
               name: "addItem",
               url: "admin/add/item/",
               defaults: new { controller = "AdminItems", action = "AddItem" }
           );

            routes.MapRoute(
               name: "editItem",
               url: "admin/edit/item/{vendorCode}",
               defaults: new { controller = "AdminItems", action = "EditItem" }
           );

            routes.MapRoute(
               name: "deleteItem",
               url: "admin/delete/item/{id}",
               defaults: new { controller = "AdminItems", action = "DeleteItem" }
           );

            routes.MapRoute(
               name: "adminOrders",
               url: "admin/orders",
               defaults: new { controller = "AdminOrder", action = "Index" }
           );

            routes.MapRoute(
               name: "editOrder",
               url: "admin/order/edit/{id}",
               defaults: new { controller = "AdminOrder", action = "EditOrder" }
           );

            routes.MapRoute(
               name: "adminNews",
               url: "admin/news",
               defaults: new { controller = "AdminNews", action = "Index" }
           );

            routes.MapRoute(
               name: "addAdminNews",
               url: "admin/news/add",
               defaults: new { controller = "AdminNews", action = "AddNews" }
           );

            routes.MapRoute(
               name: "editAdminNews",
               url: "admin/news/edit/{id}",
               defaults: new { controller = "AdminNews", action = "EditNews", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "admiStocks",
               url: "admin/stocks",
               defaults: new { controller = "AdminStocks", action = "Index" }
           );

            routes.MapRoute(
               name: "addAdminStocks",
               url: "admin/stocks/add",
               defaults: new { controller = "AdminStocks", action = "AddStocks" }
           );

            routes.MapRoute(
               name: "editAdminStocks",
               url: "admin/stocks/edit/{id}",
               defaults: new { controller = "AdminStocks", action = "EditStocks", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "adminReviews",
               url: "admin/reviews",
               defaults: new { controller = "AdminReviews", action = "Index" }
           );

            routes.MapRoute(
               name: "adminAboutCompany",
               url: "admin/about",
               defaults: new { controller = "AdminAboutInfo", action = "Index" }
           );

            routes.MapRoute(
               name: "adminContacts",
               url: "admin/contacts",
               defaults: new { controller = "AdminMainContacts", action = "Index" }
           );

            routes.MapRoute(
               name: "adminPrices",
               url: "admin/prices",
               defaults: new { controller = "AdminPrices", action = "Index" }
           );

            routes.MapRoute(
               name: "adminPartners",
               url: "admin/partners",
               defaults: new { controller = "AdminPartners", action = "Index" }
           );
            //End of Admin Part

            routes.MapRoute(
               name: "backCall",
               url: "backCall",
               defaults: new { controller = "Home", action = "BackCall" }
           );

           // routes.MapRoute(
           //    name: "FilteredItems",
           //    url: "category/{category}",
           //    defaults: new { controller = "Items", action = "FilteredIndex", category = UrlParameter.Optional }
           //);

            routes.MapRoute(
               name: "Items",
               url: "category/{category}",
               defaults: new { controller = "Items", action = "Index", category = UrlParameter.Optional}
           );

            routes.MapRoute(
               name: "productWithSub",
               url: "product/{name}/{vendorCode}",
               defaults: new { controller = "Item", action = "Index", subCategory = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "product",
               url: "product/{name}/{vendorCode}",
               defaults: new { controller = "Item", action = "Index" }
            );

            routes.MapRoute(
               name: "itemsPopular",
               url: "category/popular/{category}/{subCategory}",
               defaults: new { controller = "Items", action = "Popular", category = UrlParameter.Optional, subCategory = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "itemsPriceLow",
               url: "category/price-low/{category}/{subCategory}",
               defaults: new { controller = "Items", action = "PriceLow", category = UrlParameter.Optional, subCategory = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "itemsPriceHigh",
               url: "category/price-high/{category}/{subCategory}",
               defaults: new { controller = "Items", action = "PriceHigh", category = UrlParameter.Optional, subCategory = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "itemsWithSubCat",
               url: "category/{category}/{subCategory}",
               defaults: new { controller = "Items", action = "Index", category = UrlParameter.Optional, subCategory = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "about",
               url: "about",
               defaults: new { controller = "About", action = "Index" }
           );

            routes.MapRoute(
               name: "contacts",
               url: "contacts",
               defaults: new { controller = "Contacts", action = "Index" }
           );

            routes.MapRoute(
               name: "cart",
               url: "cart",
               defaults: new { controller = "Cart", action = "Index" }
           );

            routes.MapRoute(
               name: "order",
               url: "order",
               defaults: new { controller = "Order", action = "Index" }
           );

            routes.MapRoute(
               name: "edit",
               url: "myaccount",
               defaults: new { controller = "User", action = "Edit" }
           );

            routes.MapRoute(
               name: "userOrder",
               url: "userOrder",
               defaults: new { controller = "User", action = "Orders" }
           );

            routes.MapRoute(
                name: "authentication",
                url: "authentication",
                defaults: new { controller = "User", action = "Authentication" }
            );

            routes.MapRoute(
                name: "login",
                url: "login",
                defaults: new { controller = "User", action = "Login" }
            );

            routes.MapRoute(
                name: "userLogout",
                url: "userLogout",
                defaults: new { controller = "User", action = "Logout" }
            );

            routes.MapRoute(
               name: "registration",
               url: "registration",
               defaults: new { controller = "User", action = "Registration" }
            );

            routes.MapRoute(
              name: "restorePassword",
              url: "restorePassword",
              defaults: new { controller = "User", action = "RestorePassword" }
           );

            routes.MapRoute(
               name: "restorePasswordMessage",
               url: "restorePasswordMessage",
               defaults: new { controller = "User", action = "RestorePasswordMessage" }
            );

            routes.MapRoute(
                name: "news",
                url: "news",
                defaults: new { controller = "News", action = "Index" }
            );

            routes.MapRoute(
                name: "newsById",
                url: "news/{id}",
                defaults: new { controller = "News", action = "GetNewsById", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "stocks",
                url: "stocks",
                defaults: new { controller = "Stocks", action = "Index" }
            );

            routes.MapRoute(
                name: "stocksById",
                url: "stocks/{id}",
                defaults: new { controller = "Stocks", action = "GetStocksById", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "intime",
                url: "intime/city",
                defaults: new { controller = "Order", action = "GetInTimeCities" }
            );

            routes.MapRoute(
                name: "reviews",
                url: "reviews",
                defaults: new { controller = "Reviews", action = "Index" }
            );

            routes.MapRoute(
                name: "checkout",
                url: "checkout",
                defaults: new { controller = "Order", action = "Index" }
           );

            routes.MapRoute(
                name: "delivery",
                url: "delivery",
                defaults: new { controller = "Delivery", action = "Index" }
           );

            routes.MapRoute(
                name: "prices",
                url: "prices",
                defaults: new { controller = "Prices", action = "Index" }
           );

            routes.MapRoute(
                name: "language",
                url: "language/{lang}",
                defaults: new { controller = "Language", action = "ChangeCulture", lang = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
