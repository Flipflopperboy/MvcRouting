using System.Web;
using System.Web.Routing;

namespace Flip.Web.Routing
{
    public abstract class RequiredRouteConstraint<TValue> : RequiredRouteConstraint
    {
        protected abstract bool MatchValue(TValue value);

        protected override bool Match(object value)
        {
            return (value is TValue) ? MatchValue((TValue)value) : false;
        }
    }

    public class RequiredRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
                          RouteDirection routeDirection)
        {
            return values.ContainsKey(parameterName) && Match(values[parameterName]);
        }

        protected virtual bool Match(object value)
        {
            return value != null;
        }
    }
}