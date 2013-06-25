using Flip.Web.Routing;

namespace System.Web.Routing
{
    public static class RouteCollectionExtensions
    {
        public static Route MapRoute(this RouteCollection routes, string url, RouteBuilder builder)
        {
            return builder.Build(routes, url);
        }
    }
}