using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Flip.Web.Routing;
using Routes;
using Routes.Product;

namespace Flip.Web.Mvc.Generator
{
    public sealed class Test
    {
        public static void ConfigureRotues(RouteCollection routes)
        {
            routes.MapRoute("", Home.Index.Map());
            routes.MapRoute("", Details.Map(
                id: Is
                    .Optional()
                    .InRange(1, 100)));
        }
    }
}

namespace Routes
{
    public static class Home
    {
        public static class Index
        {
            public static RouteBuilder Map()
            {
                return new RouteBuilder
                           {
                               ControllerName = "Home",
                               ActionName = "Index",
                               RouteName = "HomeIndex"
                           };
            }
        }
    }
}

namespace Routes.Product
{
    public static class Details
    {
        public static RouteBuilder Map(IParameterBuilder id = null)
        {
            return new RouteBuilder
                       {
                           ControllerName = ControllerName,
                           ActionName = ActionName,
                           RouteName = RouteName,
                           Parameters = new Dictionary<string, IParameterBuilder>
                                            {
                                                {"id", id}
                                            }
                       };
        }

        public static string RouteUrl(this UrlHelper url, int id)
        {
            return url.RouteUrl(RouteName, new {id});
        }

        public static string JavascriptRouteBuilder(this UrlHelper url, int? id = null)
        {
            return "";
        }

        public const string ControllerName = "Home";
        public const string ActionName = "Details";
        public const string RouteName = "HomeIndex";
    }
}