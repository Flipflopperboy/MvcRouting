using System.Collections.Generic;
using System.Web.Routing;

namespace Flip.Web.Routing
{
    public class ParameterBuilder : IParameterBuilder
    {
        public ParameterBuilder()
        {
            _constraints = new List<IRouteConstraint>();
        }

        public object Default { get; set; }

        IEnumerable<IRouteConstraint> IParameterBuilder.Constraints
        {
            get { return _constraints; }
        }

        ParameterBuilder IParameterBuilder.AddConstraint(IRouteConstraint constraint)
        {
            _constraints.Add(constraint);
            return this;
        }

        private readonly List<IRouteConstraint> _constraints;
    }
}