using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Flip.Web.Routing
{
    public class RouteBuilder
    {
        public string RouteName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Dictionary<string, IParameterBuilder> Parameters { get; set; }

        public Route Build(RouteCollection routes, string url)
        {
            Route route = routes.MapRoute(RouteName, url);
            route.Defaults.Add("controller", ControllerName);
            route.Defaults.Add("action", ActionName);
            foreach (var parameter in Parameters)
            {
                if (parameter.Value.Default != null)
                {
                    route.Defaults.Add(parameter.Key, parameter.Value.Default);
                }
                foreach (IRouteConstraint constraint in parameter.Value.Constraints)
                {
                    route.Constraints.Add(parameter.Key, constraint);
                }
            }
            return route;
        }
    }
}