using System.Collections.Generic;
using System.Web.Routing;

namespace Flip.Web.Routing
{
    public interface IParameterBuilder
    {
        object Default { get; }
        IEnumerable<IRouteConstraint> Constraints { get; }
        ParameterBuilder AddConstraint(IRouteConstraint constraint);
    }
}
