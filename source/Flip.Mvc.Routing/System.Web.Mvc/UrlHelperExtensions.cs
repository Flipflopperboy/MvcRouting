using System.Web.Routing;
using Flip.Web.Routing;

namespace System.Web.Mvc
{
	public static class UrlHelperExtensions
	{
		public static string AwsomeRouteUrl(this UrlHelper url, string routeName, bool useRouteData = true)
		{
			if (string.IsNullOrEmpty(routeName))
			{
				throw new ArgumentException("routeName may not be empty");
			}

			RouteBase routeBase = url.RouteCollection[routeName];
			if (routeBase == null)
			{
				throw new ArgumentException(string.Format("Route {0} could not be found", routeName));
			}

			var route = url.RouteCollection[routeName] as Route;
			if (route == null)
			{
				throw new ArgumentException(string.Format("Route {0} is not a valid route", routeName));
			}

			var builder = new UrlBuilder(new UrlComposer(), route);
			return useRouteData ? builder.Build(url.RequestContext.RouteData.Values) : builder.Build();
		}
	}
}